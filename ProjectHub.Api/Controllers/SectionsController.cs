using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SectionDtos;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Services;

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
}
