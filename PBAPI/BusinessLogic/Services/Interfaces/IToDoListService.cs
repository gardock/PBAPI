using BusinessLogic.Dto.ObjectsDto;
using DB.Entities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IToDoListService
    {
        Task<bool> ChangeToDoListItemOrderAsync(int id, byte newOrder);
        Task<bool> CreateNewToDoListItemAsync(ToDoListItemAddEditDto toDoListItemDto);
        Task<bool> DeleteToDoListItemAsync(int id);
        Task<List<ToDoListItem>> GetAllActiveAsync();
        Task<List<ToDoListItem>> GetAllAsync();
        Task<ToDoListItem?> GetOneAsync(int id);
        Task<bool> UpdateAsync(int id, ToDoListItemAddEditDto toDoListItemDto);
    }
}