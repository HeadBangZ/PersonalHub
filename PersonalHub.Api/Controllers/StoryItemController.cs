using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using PersonalHub.Infrastructure.Repositories;

namespace PersonalHub.Api.Controllers
{
    [Route("api/storyitems")]
    [ApiController]
    public class StoryItemController : ControllerBase
    {
        public StoryItemController()
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StoryItem>> PostUserStory([FromBody] StoryItem storyItemDto)
        {
            var item = storyItemDto;

            return Created();

            //return Created($"~/api/storyitems/{userStory.Id}", userStory);
        }
    }
}
