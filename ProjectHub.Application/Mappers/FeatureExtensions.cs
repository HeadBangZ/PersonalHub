using ProjectHub.Application.DTOs.FeatureDtos;
using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Application.Mappers;

// TODO: Clean up
public static class FeatureExtensions
{
    public static FeatureDtoResponse MapFeatureToDto(this Feature feature)
    {
        return new FeatureDtoResponse(
            feature.Id.Id,
            feature.Name,
            feature.Description,
            feature.Activities,
            feature.Importance,
            feature.IsCompleted,
            feature.CreatedAt,
            feature.ModifiedAt
        );
    }

    public static Feature MapCreateDtoToFeature(this CreateFeatureDtoRequest request)
    {
        return new Feature(
           request.Name,
           request.Description
        );
    }
}


