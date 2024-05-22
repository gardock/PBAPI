using BusinessLogic.Result;
using DB.Entities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IToDoListReadService
    {
        Task<ServiceResult<List<ToDoListItem>>> GetAllActiveAsync();
        Task<ServiceResult<List<ToDoListItem>>> GetAllAsync();
        Task<ServiceResult<ToDoListItem?>> GetOneAsync(int id);
    }
}