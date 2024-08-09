using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Application.Extensions;

public static class FeatureExtensions
{
    public static FeatureDto ToFeatureDto(this Feature feature)
    {
        return new FeatureDto(
           feature.Id,
           feature.Name,
           feature.Description,
           feature.Activities,
           feature.CreatedAt,
           feature.UpdatedAt
        );
    }

    public static Feature ToFeature(this FeatureDto featureDto)
    {
        return new Feature(
           featureDto.Id,
           featureDto.Name,
           featureDto.Description,
           featureDto.Items,
           featureDto.CreatedAt,
           featureDto.UpdatedAt
        );
    }

    public static Feature ToFeature(this CreateFeatureDto featureDto)
    {
        return new Feature(
           featureDto.Name,
           featureDto.Description
        );
    }
}


