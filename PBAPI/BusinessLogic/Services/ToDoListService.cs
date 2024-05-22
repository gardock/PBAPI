using BusinessLogic.Dto.ObjectsDto;
using BusinessLogic.Enums;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Result;
using BusinessLogic.Services.Interfaces;
using DB.Entities;
using DB.Enums;

namespace BusinessLogic.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListItemRepository _toDoListRepository;
        private readonly IToDoListReadService _toDoListReadService;
        private readonly IToDoListOrderingService _toDoListOrderingService;

        public ToDoListService(IToDoListItemRepository toDoListRepository, IToDoListReadService toDoListReadService, IToDoListOrderingService toDoListOrderingService)
        {
            _toDoListRepository = toDoListRepository;
            _toDoListReadService = toDoListReadService;
            _toDoListOrderingService = toDoListOrderingService;
        }

        public async Task<ServiceResult> CreateNewToDoListItemAsync(ToDoListItemAddEditDto toDoListItemDto)
        {
            var serviceResult = await _toDoListReadService.GetAllActiveAsync();
            if (!serviceResult.IsSuccess)
                return serviceResult;

            var activeToDoListItems = serviceResult.Data!;
            if (activeToDoListItems.Exists(x => x.Title == toDoListItemDto.Title))
                return new(ServiceResultStatus.Duplicated);

            var newToDoListItem = ToDoListItem.CreateNew(toDoListItemDto.Title, toDoListItemDto.Description);

            byte order = 1;
            if (activeToDoListItems.Count != 0)
            {
                order = activeToDoListItems.Max(x => x.Order);
                if (order >= byte.MaxValue)
                    return new(ServiceResultStatus.MaxListSizeReached);
                order++;
            }
            newToDoListItem.Order = order;

            await _toDoListRepository.AddAsync(newToDoListItem);

            return new(ServiceResultStatus.Success);
        }

        public async Task<ServiceResult> UpdateAsync(int id, ToDoListItemAddEditDto toDoListItemDto)
        {
            var existingToDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (existingToDoListItem is null)
                return new(ServiceResultStatus.NotFound);

            var serviceResult = await _toDoListReadService.GetAllActiveAsync();
            if (!serviceResult.IsSuccess)
                return serviceResult;

            var activeToDoListItems = serviceResult.Data!;
            if (activeToDoListItems.Exists(x => x.Title == toDoListItemDto.Title))
                return new(ServiceResultStatus.Duplicated);

            existingToDoListItem.Title = toDoListItemDto.Title;
            existingToDoListItem.Description = toDoListItemDto.Description;
            await _toDoListRepository.UpdateAsync(existingToDoListItem);
            return new(ServiceResultStatus.Success);
        }

        public async Task<ServiceResult> DeleteToDoListItemAsync(int id)
        {
            var toDoListItem = await _toDoListRepository.GetOneAsync(id);
            if (toDoListItem is null)
                return new(ServiceResultStatus.Success);
            if (toDoListItem.Status == ToDoListItemStatus.InProgress)
                return new(ServiceResultStatus.ItemIsInProgress);

            await _toDoListRepository.DeleteAsync(id);

            return await _toDoListOrderingService.UpdateListItemOrder(toDoListItem.Order, true);
        }
    }
}