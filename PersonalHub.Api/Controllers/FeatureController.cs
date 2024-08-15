using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Api.Controllers;

[Route("api/features")]
[ApiController]
public class FeatureController : ControllerBase
{
    private readonly FeatureService _featureService;

    public FeatureController(FeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Feature>> PostFeature([FromBody] CreateFeatureDto featureDto)
    {
        var feature = await _featureService.AddFeature(featureDto);

        return Created($"~/api/features/{feature.Id}", feature);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<FeatureDto>> GetFeature([FromRoute] Guid id)
    {
        var feature = await _featureService.GetFeature(id);

        if (feature == null)
        {
            return NotFound();
        }

        return Ok(feature);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<FeatureDto>> GetAllFeatures()
    {
        var features = await _featureService.GetAllFeatures();

        return Ok(features);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateFeature([FromRoute] Guid id, [FromBody] UpdateFeatureDto featureDto)
    {
        if (id != featureDto.Id)
        {
            return BadRequest("Id Mismatch");
        }

        await _featureService.UpdateFeature(id, featureDto);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteFeature([FromRoute] Guid id)
    {
        var feature = await _featureService.GetFeature(id);

        if (feature == null)
        {
            return NotFound();
        }

        await _featureService.DeleteFeature(id);

        return NoContent();
    }
}
