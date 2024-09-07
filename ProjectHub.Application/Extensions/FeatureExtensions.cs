using ProjectHub.Application.DTOs.FeatureDtos;
using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Application.Extensions;

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

    // TODO: Update this map
    // OPTIMIZE: How we update
    public static Feature MapDtoToFeature(this UpdateFeatureDtoRequest request, Feature existingFeature)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            existingFeature.Name = request.Name;
        }

        if (!string.IsNullOrEmpty(request.Description))
        {
            existingFeature.Description = request.Description;
        }

        if (request.Activities != null)
        {
            existingFeature.Activities = request.Activities;
        }

        if (request.Importance.HasValue)
        {
            existingFeature.Importance = request.Importance.Value;
        }

        if (request.IsCompleted.HasValue)
        {
            existingFeature.IsCompleted = request.IsCompleted.Value;
        }

        return existingFeature;
    }

    public static Feature MapCreateDtoToFeature(this CreateFeatureDtoRequest request)
    {
        return new Feature(
           request.Name,
           request.Description
        );
    }
}


