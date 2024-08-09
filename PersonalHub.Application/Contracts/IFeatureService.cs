using PersonalHub.Application.DTOs;
namespace PersonalHub.Application.Contracts;

public interface IFeatureService
{
    Task<FeatureDto> AddFeature(CreateFeatureDto featureDto);
    Task<FeatureDto?> GetFeature(string id);
    Task<List<FeatureDto>> GetAllFeatures();
    Task UpdateFeature(string id, UpdateFeatureDto featureDto);
    Task DeleteFeature(string id);
    Task<bool> FeatureExists(string id);
}
