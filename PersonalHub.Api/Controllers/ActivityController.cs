using Microsoft.AspNetCore.Mvc;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Api.Controllers;

[Route("api/activities")]
[ApiController]
public class ActivityController : ControllerBase
{
    public ActivityController()
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Activity>> PostActivity([FromBody] Activity activityDto)
    {
        var activity = activityDto;

        return Created();

        //return Created($"~/api/storyitems/{userStory.Id}", userStory);
    }
}
