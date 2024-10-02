using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.FeatureDtos;
using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Api.Controllers;

[Route("api/v{v:apiVersion}/features")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Feature>> PostFeature([FromBody] CreateFeatureDtoRequest request)
    {
        var feature = await _featureService.AddFeature(request);

        return CreatedAtAction(
            nameof(GetFeature),
            new { id = feature.Id },
            feature);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<FeatureDtoResponse>> GetFeature([FromRoute] Guid id)
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
    public async Task<ActionResult<FeatureDtoResponse>> GetAllFeatures()
    {
        var features = await _featureService.GetAllFeatures();

        return Ok(features);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateFeature([FromRoute] Guid id, [FromBody] UpdateFeatureDtoRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("Id Mismatch");
        }

        await _featureService.UpdateFeature(id, request);

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
