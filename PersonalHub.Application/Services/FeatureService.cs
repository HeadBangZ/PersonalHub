using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.Workspace.Enums;

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
        var feature = featureDto.MapCreateDtoToFeature();

        await _featureRepository.AddAsync(feature);
        return feature.MapFeatureToDto();
    }

    public async Task<FeatureDto?> GetFeature(Guid id)
    {
        var feature = await _featureRepository.GetAsync(id);

        if (feature == null)
        {
            return null;
        }

        var featureDto = feature.MapFeatureToDto();

        return featureDto;
    }

    public async Task<List<FeatureDto>> GetAllFeatures()
    {
        var featureDto = new List<FeatureDto>();
        var features = await _featureRepository.GetAllAsync();

        foreach (var feature in features)
        {
            featureDto.Add(feature.MapFeatureToDto());
        }
        return featureDto;
    }

    public async Task DeleteFeature(Guid id)
    {
        await _featureRepository.DeleteAsync(id);
    }

    public async Task UpdateFeature(Guid id, UpdateFeatureDto featureDto)
    {
        var existingFeature = await _featureRepository.GetAsync(id);

        if (existingFeature == null)
        {
            throw new Exception($"Feature with ID - {id} was not found");
        }

        var updatedFeature = featureDto.MapDtoToFeature(existingFeature);

        updatedFeature.UpdatedAt = DateTime.Now;

        await _featureRepository.UpdateAsync(updatedFeature);
    }
}
