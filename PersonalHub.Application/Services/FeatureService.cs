using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Domain.Contracts;

namespace PersonalHub.Application.Services;

public class FeatureService : IFeatureService
{
    private readonly IFeatureRepository _featureRepository;
    public FeatureService(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<FeatureDto> AddFeature(CreateFeatureDto featureDto)
    {
        var feature = featureDto.ToFeature();

        await _featureRepository.AddAsync(feature);
        return feature.ToFeatureDto();
    }

    public async Task<FeatureDto?> GetFeature(string id)
    {
        var featureId = Guid.Parse(id);
        var feature = await _featureRepository.GetAsync(featureId);

        if (feature == null)
        {
            return null;
        }

        var featureDto = feature.ToFeatureDto();

        return featureDto;
    }

    public async Task<List<FeatureDto>> GetAllFeatures()
    {
        var featureDto = new List<FeatureDto>();
        var features = await _featureRepository.GetAllAsync();

        foreach (var feature in features)
        {
            featureDto.Add(feature.ToFeatureDto());
        }
        return featureDto;
    }

    public async Task DeleteFeature(string id)
    {
        var featureId = Guid.Parse(id);

        await _featureRepository.DeleteAsync(featureId);
    }

    public async Task UpdateFeature(string id, UpdateFeatureDto featureDto)
    {
        var featureId = Guid.Parse(id);
        var feature = await _featureRepository.GetAsync(featureId);

        if (feature == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(featureDto.Name))
        {
            feature.Name = featureDto.Name;
        }

        if (!string.IsNullOrEmpty(featureDto.Description))
        {
            feature.Description = featureDto.Description;
        }

        feature.UpdatedAt = DateTime.UtcNow;

        await _featureRepository.UpdateAsync(feature);
    }
}
