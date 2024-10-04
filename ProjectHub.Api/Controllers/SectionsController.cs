using Microsoft.AspNetCore.Mvc;
using ProjectHub.Api.Validators.SectionValidators;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SectionDtos;
using ProjectHub.Domain.Workspace.Entities;
using System.Text;

namespace ProjectHub.Api.Controllers;

[Route("api/v{v:apiVersion}/sections")]
[ApiController]
public class SectionsController : ControllerBase
{
    private readonly ISectionService _sectionService;

    public SectionsController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Section>> PostSection([FromBody] CreateSectionDtoRequest request)
    {
        var validator = new CreateSectionValidator();
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

        var section = await _sectionService.AddSectionAsync(request);

        if (section == null)
        {
            return NotFound($"Space with Id - {request.SpaceId} does not exist");
        }

        return CreatedAtAction(
            nameof(GetSection),
            new { id = section.Id },
            section);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SectionDtoResponse>> GetSection([FromRoute] Guid id)
    {
        var section = await _sectionService.GetSectionAsync(id);

        if (section == null)
        {
            return NotFound();
        }

        return Ok(section);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SectionDtoResponse>> GetAllSections()
    {
        var sections = await _sectionService.GetAllSectionAsync();

        return Ok(sections);
    }
}
