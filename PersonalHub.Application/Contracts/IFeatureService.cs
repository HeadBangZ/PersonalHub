using PersonalHub.Application.DTOs;

namespace PersonalHub.Application.Contracts;

public interface IFeatureService
{
    Task<FeatureDto> AddFeature(CreateFeatureDto featureDto);
    Task<FeatureDto?> GetFeature(Guid id);
    Task<List<FeatureDto>> GetAllFeatures();
    Task UpdateFeature(Guid id, UpdateFeatureDto featureDto);
    Task DeleteFeature(Guid id);
}
