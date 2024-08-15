using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.Runtime.CompilerServices;

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
            feature.Importance.ToString(),
            feature.IsCompleted,
            feature.CreatedAt,
            feature.UpdatedAt
        );
    }

    //public static Feature MapDtoToFeature(this FeatureDto featureDto)
    //{
    //    return new Feature(
    //       featureDto.Id,
    //       featureDto.Name,
    //       featureDto.Description,
    //       featureDto.Activities,
    //       featureDto.Importance,
    //       featureDto.IsCompleted,
    //       featureDto.CreatedAt,
    //       featureDto.UpdatedAt
    //    );
    //}

    public static Feature MapCreateDtoToFeature(this CreateFeatureDto createRequest)
    {
        return new Feature(
           createRequest.Name,
           createRequest.Description
        );
    }
}


