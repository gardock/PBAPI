using BusinessLogic.Enums;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Result;
using BusinessLogic.Services.Interfaces;

namespace BusinessLogic.Services
{
    public class ToDoListOrderingService : IToDoListOrderingService
    {
        private readonly IToDoListItemRepository _toDoListRepository;
        private readonly IToDoListReadService _toDoListReadService;

        public ToDoListOrderingService(IToDoListItemRepository toDoListRepository, IToDoListReadService toDoListReadService)
        {
            _toDoListRepository = toDoListRepository;
            _toDoListReadService = toDoListReadService;
        }

        public async Task<ServiceResult> ChangeToDoListItemOrderAsync(int id, byte newOrder)
        {
            var maxOrderResult = await GetMaxOrder();
            if (!maxOrderResult.IsSuccess)
                return maxOrderResult;

            var maxOrder = maxOrderResult.Data; // if new order is bigger than maxorder - set new order as max order
            if (newOrder > maxOrder)
                newOrder = maxOrder;

            var toDoListItemResult = await _toDoListReadService.GetOneAsync(id);
            if (!toDoListItemResult.IsSuccess)
                return toDoListItemResult;

            var toDoListItem = toDoListItemResult.Data!;
            int oldOrder = toDoListItem.Order;
            if (oldOrder < newOrder)
            {
                await UpdateListItemOrder(oldOrder + 1, newOrder, true);
            }
            else if (oldOrder > newOrder)
            {
                await UpdateListItemOrder(newOrder + 1, oldOrder, false);
            }
            else
                return new(ServiceResultStatus.Success);

            toDoListItem.Order = newOrder;
            await _toDoListRepository.UpdateAsync(toDoListItem);
            return new(ServiceResultStatus.Success);
        }

        public async Task<ServiceResult> UpdateListItemOrder(int startOrder, int endOrder, bool toFront)
        {
            var allItemsResult = await _toDoListReadService.GetAllActiveAsync();
            if (!allItemsResult.IsSuccess)
                return allItemsResult;

            var itemsWithHigherOrder = allItemsResult.Data!
                .Where(x => x.Order >= startOrder
                       && x.Order <= endOrder)
                .ToList();

            foreach (var item in itemsWithHigherOrder)
            {
                if (toFront)
                    item.Order--;
                else
                    item.Order++;
                await _toDoListRepository.UpdateAsync(item);
            }

            return new(ServiceResultStatus.Success);
        }
        public async Task<ServiceResult> UpdateListItemOrder(int startOrder, bool toFront)
        {
            var maxOrderResult = await GetMaxOrder();
            if (!maxOrderResult.IsSuccess)
                return maxOrderResult;

            return await UpdateListItemOrder(startOrder, maxOrderResult.Data, toFront);
        }

        public async Task<ServiceResult<byte>> GetMaxOrder()
        {
            var toDoItemsListResult = await _toDoListReadService.GetAllActiveAsync();
            if (!toDoItemsListResult.IsSuccess)
                return new(toDoItemsListResult.ServiceResultStatus);

            return new(toDoItemsListResult.Data!.Max(o => o.Order));
        }
    }
}
