using BusinessLogic.Result;

namespace BusinessLogic.Services.Interfaces
{
    public interface IToDoListOrderingService
    {
        Task<ServiceResult> ChangeToDoListItemOrderAsync(int id, byte newOrder);
        Task<ServiceResult<byte>> GetMaxOrder();
        Task<ServiceResult> UpdateListItemOrder(int startOrder, bool toFront);
        Task<ServiceResult> UpdateListItemOrder(int startOrder, int endOrder, bool toFront);
    }
}