using BusinessLogic.Dto.ObjectsDto;
using BusinessLogic.Services.Interfaces;
using DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;

        //TODO wstrzykujemy serwis 
        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        //TODO metoda
        [HttpXXXXXX]
        public async Task<ActionResult<IEnumerable<ToDoListItem>>> GetList()
        {
            return Ok(await _toDoListService.GetAllActiveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _toDoListService.DeleteToDoListItemAsync(id);
            return result switch
            {
                true => NoContent(),
                false => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }

        //TODO metoda
        [HttpXXXXXX]
        public async Task<ActionResult> Add([FromBody] ToDoListItemAddEditDto product)
        {
            var result = await _toDoListService.CreateNewToDoListItemAsync(product);

            return result switch
            {
                true => NoContent(),
                false => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }

        [HttpXXXXXX("change_order")]
        public async Task<ActionResult> ChangeOrder([FromBody] ToDoListItemChangeOrderDto product)
        {
            var result = await _toDoListService.ChangeToDoListItemOrderAsync(product.Id, product.NewOrder);

            return result switch
            {
                true => NoContent(),
                false => StatusCode(StatusCodes.Status405MethodNotAllowed)
            };
        }
    }
}
