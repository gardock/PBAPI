using BusinessLogic.Dto.ObjectsDto;
using BusinessLogic.Enums;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListReadService _toDoListReadService;
        private readonly IToDoListOrderingService _toDoListOrderingService;

        public ToDoListController(IToDoListService toDoListService, IToDoListReadService toDoListReadService, IToDoListOrderingService toDoListOrderingService)
        {
            _toDoListService = toDoListService;
            _toDoListReadService = toDoListReadService;
            _toDoListOrderingService = toDoListOrderingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _toDoListReadService.GetAllActiveAsync();
            if (result.IsSuccess)
                return Ok(result.Data);

            return HandleServiceErrorResult(result.ServiceResultStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _toDoListService.DeleteToDoListItemAsync(id);
            if (result.IsSuccess)
                return NoContent();

            return HandleServiceErrorResult(result.ServiceResultStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ToDoListItemAddEditDto product)
        {
            var result = await _toDoListService.CreateNewToDoListItemAsync(product);
            if (result.IsSuccess)
                return Created();

            return HandleServiceErrorResult(result.ServiceResultStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ToDoListItemAddEditDto product)
        {
            var result = await _toDoListService.UpdateAsync(id, product);
            if (result.IsSuccess)
                return NoContent();

            return HandleServiceErrorResult(result.ServiceResultStatus);
        }

        [HttpPost("change_order")]
        public async Task<IActionResult> ChangeOrder([FromBody] ToDoListItemChangeOrderDto product)
        {
            var result = await _toDoListOrderingService.ChangeToDoListItemOrderAsync(product.Id, product.NewOrder);
            if (result.IsSuccess)
                return NoContent();

            return HandleServiceErrorResult(result.ServiceResultStatus);
        }

        private StatusCodeResult HandleServiceErrorResult(ServiceResultStatus status) 
            => status switch
        {
            ServiceResultStatus.NotFound => NotFound(),
            ServiceResultStatus.MaxListSizeReached => BadRequest(),
            ServiceResultStatus.Duplicated or ServiceResultStatus.ItemIsInProgress => Conflict(),
            _ => StatusCode(StatusCodes.Status500InternalServerError),
        };
    }
}