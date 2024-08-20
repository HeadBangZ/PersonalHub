using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Application.Extensions;

public static class FeatureExtensions
{
    public static FeatureDto MapFeatureToDto(this Feature feature)
    {
        return new FeatureDto(
            feature.Id,
            feature.Name,
            feature.Description,
            feature.Activities,
            feature.Importance,
            feature.IsCompleted,
            feature.CreatedAt,
            feature.UpdatedAt
        );
    }

    public static Feature MapDtoToFeature(this FeatureDto featureDto)
    {
        return new Feature(
           featureDto.Id,
           featureDto.Name,
           featureDto.Description,
           featureDto.Activities,
           featureDto.Importance,
           featureDto.IsCompleted,
           featureDto.CreatedAt,
           featureDto.UpdatedAt
        );
    }

    // TODO: Update this map
    // OPTIMIZE: How we update
    public static Feature MapDtoToFeature(this UpdateFeatureDto featureDto, Feature existingFeature)
    {
        if (!string.IsNullOrEmpty(featureDto.Name))
        {
            existingFeature.Name = featureDto.Name;
        }

        if (!string.IsNullOrEmpty(featureDto.Description))
        {
            existingFeature.Description = featureDto.Description;
        }

        if (featureDto.Activities != null)
        {
            existingFeature.Activities = featureDto.Activities;
        }

        if (featureDto.Importance.HasValue)
        {
            existingFeature.Importance = featureDto.Importance.Value;
        }

        if (featureDto.IsCompleted.HasValue)
        {
            existingFeature.IsCompleted = featureDto.IsCompleted.Value;
        }

        return existingFeature;
    }

    public static Feature MapCreateDtoToFeature(this CreateFeatureDto createRequest)
    {
        return new Feature(
           createRequest.Name,
           createRequest.Description
        );
    }
}


