using DB.Entities;

namespace BusinessLogic.Repositories.Interfaces
{
    public interface IToDoListItemRepository
    {
        Task AddAsync(ToDoListItem toDoListItem);
        Task DeleteAsync(int id);
        Task<IEnumerable<ToDoListItem>> GetAllAsync();
        Task<ToDoListItem?> GetOneAsync(int id);
        Task UpdateAsync(ToDoListItem toDoListItem);
    }
}