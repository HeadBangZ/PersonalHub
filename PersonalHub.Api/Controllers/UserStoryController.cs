using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Entities;

namespace PersonalHub.Api.Controllers;

[Route("api/userstories")]
[ApiController]
public class UserStoryController : ControllerBase
{
    private readonly UserStoryService _userStoryService;

    public UserStoryController(UserStoryService userStoryService)
    {
        _userStoryService = userStoryService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<UserStory>> PostUserStory([FromBody] CreateUserStoryDto userStoryDto)
    {
        var userStory = await _userStoryService.AddUserStory(userStoryDto);

        return Created($"~/api/userstories/{userStory.Id}", userStory);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserStoryDto>> GetUserStory([FromRoute] string id)
    {
        var userStory = await _userStoryService.GetUserStory(id);

        if (userStory == null)
        {
            return NotFound();
        }

        return Ok(userStory);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserStoryDto>> GetAllUserStories()
    {
        var userStories = await _userStoryService.GetAllUserStories();

        return Ok(userStories);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUserStory([FromRoute] string id, [FromBody] UpdateUserStoryDto userStoryDto)
    {
        var exist = await _userStoryService.UserStoryExist(id);

        if (!exist)
        {
            return NotFound();
        }

        await _userStoryService.UpdateUserStory(id, userStoryDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUserStory([FromRoute] string id)
    {
        var exists = await _userStoryService.UserStoryExist(id);

        if (!exists)
        {
            return NotFound();
        }

        await _userStoryService.DeleteUserStory(id);

        return NoContent();
    }
}
