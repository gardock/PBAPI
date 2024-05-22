using BusinessLogic.Dto.ObjectsDto;
using BusinessLogic.Result;
using DB.Entities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IToDoListService
    {
        Task<ServiceResult> CreateNewToDoListItemAsync(ToDoListItemAddEditDto toDoListItemDto);
        Task<ServiceResult> DeleteToDoListItemAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, ToDoListItemAddEditDto toDoListItemDto);
    }
}