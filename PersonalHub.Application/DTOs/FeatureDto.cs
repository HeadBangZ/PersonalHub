using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateFeatureDto(
    [Required][StringLength(75)] string Name,
    string? Description
);

public record FeatureDto(
    Guid Id,
    string Name,
    string? Description,
    List<Activity> Activities,
    string Importance,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
