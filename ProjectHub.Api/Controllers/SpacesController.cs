using Microsoft.AspNetCore.Mvc;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.FeatureDtos;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Services;
using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Api.Controllers;

[Route("api/spaces")]
[ApiController]
public class SpacesController : ControllerBase
{
    private readonly ISpaceService _spaceService;
    public SpacesController(ISpaceService spaceService)
    {
        _spaceService = spaceService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Space>> PostSpace([FromBody] CreateSpaceDtoRequest request)
    {
        var space = await _spaceService.AddSpace(request);

        return CreatedAtAction(
            nameof(GetSpace),
            new { id = space.Id },
            space);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SpaceDtoResponse>> GetSpace([FromRoute] Guid id)
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
    public async Task<ActionResult<SpaceDtoResponse>> GetAllSpaces()
    {
        var spaces = await _spaceService.GetAllSpaces();

        return Ok(spaces);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateSpace([FromRoute] Guid id, [FromBody] UpdateSpaceDtoRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("Id Mismatch");
        }

        await _spaceService.UpdateSpace(id, request);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteSpace([FromRoute] Guid id)
    {
        var space = await _spaceService.GetSpace(id);

        if (space == null)
        {
            return NotFound();
        }

        await _spaceService.DeleteSpace(id);

        return NoContent();
    }
}
