using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;

namespace PersonalHub.Api.Controllers
{
    [Route("api/todolist")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoListService _toDoListService;

        public ToDoListController(ToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ToDoList>> PostToDoList([FromBody] CreateToDoListDto toDoListDto)
        {
            var toDoList = await _toDoListService.AddAsync(toDoListDto);

            return Created($"~/api/todo-list/{toDoList.Id}", toDoList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoListDto>> GetToDoList([FromRoute] string id)
        {
            var toDoList = await _toDoListService.GetToDoList(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            return Ok(toDoList);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoListDto>> GetAllToDoLists()
        {
            var toDoLists = await _toDoListService.GetAllToDoLists();

            if (!toDoLists.Any())
            {
                return NotFound();
            }

            return Ok(toDoLists);
        }
    }
}
