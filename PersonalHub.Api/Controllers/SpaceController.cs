using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Api.Controllers;

[Route("api/space")]
[ApiController]
public class SpaceController : ControllerBase
{
    private readonly SpaceService _spaceService;
    public SpaceController(SpaceService spaceService)
    {
        _spaceService = spaceService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Space>> PostSpace([FromBody] CreateSpaceDto spaceDto)
    {
        var space = await _spaceService.AddSpace(spaceDto);

        return Created($"~/api/features/{space.Id}", space);
    }
}
