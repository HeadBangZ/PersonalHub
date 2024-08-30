using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Api.Controllers;

[Route("api/spaces")]
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

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SpaceDto>> GetFeature([FromRoute] Guid id)
    {
        var space = await _spaceService.GetSpace(id);

        if (space == null)
        {
            return NotFound();
        }

        return Ok(space);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SpaceDto>> GetAllSpaces()
    {
        var spaces = await _spaceService.GetAllSpaces();

        return Ok(spaces);
    }
}
