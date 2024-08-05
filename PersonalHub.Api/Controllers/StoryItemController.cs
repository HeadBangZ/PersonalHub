using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using PersonalHub.Infrastructure.Repositories;

namespace PersonalHub.Api.Controllers
{
    [Route("api/storyitems")]
    [ApiController]
    public class StoryItemController : ControllerBase
    {
        private readonly StoryItemService _storyItemService;
        public StoryItemController(StoryItemService storyItemService)
        {
            _storyItemService = storyItemService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StoryItem>> PostStoryItem([FromBody] CreateStoryItemDto storyItemDto)
        {
            var item = storyItemDto;

            var storyItem = await _storyItemService.AddStoryItem(storyItemDto);

            return Created($"~/api/storyitems/{storyItem.Id}", storyItem);
        }
    }
}
