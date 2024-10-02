using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProjectHub.Api.Validators.SpaceValidators;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Domain.Workspace.Entities;
using System.Text;

namespace ProjectHub.Api.Controllers;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/spaces")]
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
        var validator = new CreateSpaceValidator();
        var results = validator.Validate(request);

        if (!results.IsValid)
        {
            var sb = new StringBuilder();
            foreach (var failure in results.Errors)
            {
                sb.AppendLine($"Error: {failure.ErrorMessage}");
            }

            return BadRequest(sb.ToString());
        }

        var space = await _spaceService.AddSpaceAsync(request);

        return CreatedAtAction(
            nameof(GetSpace),
            new { id = space.Id },
            space);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SpaceDtoResponse>> GetSpace([FromRoute] Guid id)
    {
        var space = await _spaceService.GetSpaceAsync(id);

        if (space == null)
        {
            return NotFound();
        }

        return Ok(space);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SpaceDtoResponse>> GetAllSpaces()
    {
        var spaces = await _spaceService.GetAllSpacesAsync();

        return Ok(spaces);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateSpace([FromRoute] Guid id, [FromBody] UpdateSpaceDtoRequest request)
    {
        var validator = new UpdateSpaceValidator();
        var results = validator.Validate(request);

        if (!results.IsValid)
        {
            var sb = new StringBuilder();
            foreach (var failure in results.Errors)
            {
                sb.AppendLine($"Error: {failure.ErrorMessage}");
            }

            return BadRequest(sb.ToString());
        }

        if (id != request.Id)
        {
            return BadRequest("Id Mismatch");
        }

        var result = await _spaceService.UpdateSpaceAsync(id, request);

        if (!result)
        {
            return NotFound($"Space with ID - {id} was not found");
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteSpace([FromRoute] Guid id)
    {
        var space = await _spaceService.GetSpaceAsync(id);

        if (space == null)
        {
            return NotFound();
        }

        await _spaceService.DeleteSpaceAsync(id);

        return NoContent();
    }
}
