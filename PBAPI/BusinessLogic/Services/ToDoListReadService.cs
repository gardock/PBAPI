using BusinessLogic.Enums;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Result;
using BusinessLogic.Services.Interfaces;
using DB.Entities;

namespace BusinessLogic.Services
{
    public class ToDoListReadService : IToDoListReadService
    {
        private readonly IToDoListItemRepository _toDoListRepository;

        public ToDoListReadService(IToDoListItemRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<ServiceResult<List<ToDoListItem>>> GetAllActiveAsync()
        {
            var allToDoItems = await _toDoListRepository.GetAllAsync();
            if (allToDoItems is null)
                return new(ServiceResultStatus.NotFound);

            var result = allToDoItems.Where(x => !x.IsDeleted).OrderBy(o => o.Order).ToList();
            return new(result);
        }

        public async Task<ServiceResult<List<ToDoListItem>>> GetAllAsync()
        {
            var allToDoItems = await _toDoListRepository.GetAllAsync();
            if (allToDoItems is null)
                return new(ServiceResultStatus.NotFound);

            var result = allToDoItems.OrderBy(o => o.Order).ToList();
            return new(result);
        }

        public async Task<ServiceResult<ToDoListItem?>> GetOneAsync(int id)
        {
            var todoListItem = await _toDoListRepository.GetOneAsync(id);
            if (todoListItem is null)
                return new(ServiceResultStatus.NotFound);

            return new(todoListItem);
        }
    }
}
