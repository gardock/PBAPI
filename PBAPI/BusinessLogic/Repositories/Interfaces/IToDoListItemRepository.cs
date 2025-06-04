using DB.Entities;

namespace BusinessLogic.Repositories.Interfaces
{
    public interface IToDoListItemRepository
    {
        Task AddAsync(ToDoListItem toDoListItem);
        Task DeleteAsync(int id);
        Task<List<ToDoListItem>> GetAllAsync();
        Task<ToDoListItem?> GetOneAsync(int id);
        Task UpdateAsync(ToDoListItem toDoListItem);
    }
}