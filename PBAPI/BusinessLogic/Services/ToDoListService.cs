using BusinessLogic.Dto.ObjectsDto;
using BusinessLogic.Repositories;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using DB.Entities;
using DB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListItemRepository _toDoListRepository;

        public ToDoListService(IToDoListItemRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<List<ToDoListItem>> GetAllActiveAsync()
        {
            var allToDoItems = await _toDoListRepository.GetAllAsync();
            if (allToDoItems is null)
                return null;
            return allToDoItems.Where(x => !x.IsDeleted).OrderBy(o => o.Order).ToList();
        }
        public async Task<List<ToDoListItem>> GetAllAsync()
        {
            var allToDoItems = await _toDoListRepository.GetAllAsync();
            return allToDoItems.OrderBy(o => o.Order).ToList();
        }
        public async Task<ToDoListItem?> GetOneAsync(int id)
        {
            return await _toDoListRepository.GetOneAsync(id);
        }

        public async Task<bool> CreateNewToDoListItemAsync(ToDoListItemAddEditDto toDoListItemDto)
        {
            var activeToDoListItems = await GetAllActiveAsync();
            if (activeToDoListItems.Exists(x => x.Title == toDoListItemDto.Title))
                return false; //cannot place 2 items with same name

            ToDoListItem newToDoListItem = new ToDoListItem();
            newToDoListItem.Title = toDoListItemDto.Title;
            newToDoListItem.Description = toDoListItemDto.Description;
            newToDoListItem.Status = ToDoListItemStatus.Created;
            newToDoListItem.CreateDate = DateTime.Now;
            newToDoListItem.IsDeleted = false;

            byte order = 1;
            if (activeToDoListItems.Any())
            {
                order = activeToDoListItems.Max(x => x.Order);
                if (order > 254)
                    return false; //Max list size reached
                order++;
            }
            newToDoListItem.Order = order;

            await _toDoListRepository.AddAsync(newToDoListItem);

            return true;
        }

        public async Task<bool> UpdateAsync(int id, ToDoListItemAddEditDto toDoListItemDto)
        {
            var existingToDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (existingToDoListItem is null)
                return false;

            var activeToDoListItems = await GetAllActiveAsync();
            if (activeToDoListItems.Exists(x => x.Title == toDoListItemDto.Title
                                           && x.Id != id))
                return false; //cannot place 2 items with same name

            existingToDoListItem.Title = toDoListItemDto.Title;
            existingToDoListItem.Description = toDoListItemDto.Description;
            await _toDoListRepository.UpdateAsync(existingToDoListItem);
            return true;
        }

        public async Task<bool> DeleteToDoListItemAsync(int id)
        {
            var toDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (toDoListItem is null)
                return true;
            if (toDoListItem.Status == ToDoListItemStatus.InProgress)
                return false; //Cannot remove items in progress

            await _toDoListRepository.DeleteAsync(id);
            await MoveOtherItems(toDoListItem.Order, await GetMaxOrder(), true);

            return true;
        }

        public async Task<bool> ChangeToDoListItemOrderAsync(int id, byte newOrder)
        {
            var maxOrder = await GetMaxOrder(); // if new order is bigger than maxorder - set new order as max order
            if (newOrder > maxOrder) newOrder = maxOrder;

            var toDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (toDoListItem is null) return false; // there is no item with such id 

            int oldOrder = toDoListItem.Order;

            if (oldOrder < newOrder)
            {
                await MoveOtherItems(oldOrder + 1, newOrder, true);
            }
            else if (oldOrder > newOrder)
            {
                await MoveOtherItems(newOrder + 1, oldOrder, false);
            }
            else
                return false; // there is no need to change

            toDoListItem.Order = newOrder;
            _toDoListRepository.UpdateAsync(toDoListItem);
            return true;
        }

        private async Task MoveOtherItems(int startOrder, int endOrder, bool toFront)
        {
            var itemsWithHigherOrder = (await GetAllActiveAsync())
                .Where(x => x.Order >= startOrder
                       && x.Order <= endOrder)
                .ToList();

            foreach (var item in itemsWithHigherOrder)
            {
                if (toFront)
                    item.Order--;
                else
                    item.Order++;
                _toDoListRepository.UpdateAsync(item);
            }
        }

        private async Task<byte> GetMaxOrder()
        {
            var toDoItemsList = await GetAllActiveAsync();
            return toDoItemsList.Max(o => o.Order);
        }
    }
}