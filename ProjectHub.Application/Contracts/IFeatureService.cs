using PersonalHub.Application.DTOs.FeatureDtos;

namespace PersonalHub.Application.Contracts;

public interface IFeatureService
{
    Task<FeatureDtoResponse> AddFeature(CreateFeatureDtoRequest request);
    Task<FeatureDtoResponse?> GetFeature(Guid id);
    Task<List<FeatureDtoResponse>> GetAllFeatures();
    Task UpdateFeature(Guid id, UpdateFeatureDtoRequest request);
    Task DeleteFeature(Guid id);
}
