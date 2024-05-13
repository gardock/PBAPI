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

        //TODO wstrzyknijmy repozytorium

        public async Task<List<ToDoListItem>> GetAllAsync()
        {
            var allToDoItems = await _toDoListRepository.GetAllAsync();
            return allToDoItems.OrderBy(o => o.Order).ToList();
        }

        public async Task<List<ToDoListItem>> GetAllActiveAsync()
        {
            //TODO pobieranie tylko aktywnych
        }

        public async Task<ToDoListItem?> GetOneAsync(int id)
        {
            //TODO pobranie jednego elementu
        }

        public async Task<bool> CreateNewToDoListItemAsync(ToDoListItemAddEditDto toDoListItemDto)
        {
            //TODO pobranie listy aktywnych
            var activeToDoListItems; 

            //TODO czy istnieje
            if (activeToDoListItems.XXXXXX(x => x.Title == toDoListItemDto.Title))
                return false; //cannot place 2 items with same name

            ToDoListItem newToDoListItem = new ToDoListItem();
            newToDoListItem.Title = toDoListItemDto.Title;
            newToDoListItem.Description = toDoListItemDto.Description;
            newToDoListItem.Status = ToDoListItemStatus.Created;
            newToDoListItem.CreateDate = DateTime.Now;
            newToDoListItem.IsDeleted = false;

            byte order = 1;
            //TODO czy istnieje chociaż jakikolwiek wpis na liście
            if (activeToDoListItems.XXXXXX())
            {
                //TODO maksymalny element z listy
                order = activeToDoListItems.XXXXXX(x => x.Order);
                if (order > 254) 
                    return false; //Max list size reached
                order++;
            }
            newToDoListItem.Order = order;

            //TODO czego zabrakło w naszej metodzie ? 

            return true;
        }

        public async Task<bool> UpdateAsync(int id, ToDoListItemAddEditDto toDoListItemDto)
        {
            var existingToDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (existingToDoListItem is null)
                return false;

            //TODO pobranie listy
            var activeToDoListItems; 
            //TODO czy istnieje element o takim samym tytule
            if (activeToDoListItems.XXXXXX(x => x.Title == toDoListItemDto.Title
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
            //TODO zwracały fałsz gdy element jest w statusie "InProgress" - nie można usuwać takich elementów

            await _toDoListRepository.DeleteAsync(id);

            //TODO wybierz element od którego do którego cofniemy kolejność
            await MoveOtherItems(XXXXXX, XXXXXX, true);

            return true;
        }

        public async Task<bool> ChangeToDoListItemOrderAsync(int id, byte newOrder)
        {
            var toDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (toDoListItem is null) return false; // there is no item with such id 

            //TODO sprawdzić czy nowa pozycja nie przekraczamaksymalnej pozycji na liście

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
            //TODO get all items within order
            var itemsWithHigherOrderl;

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