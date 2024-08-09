using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateActivityDto(
    [Required][StringLength(75)] string Name,
    string? Description,
    Guid FeatureId,
    ActivityType? Type = null,
    Priority? Priority = null
);

public record ActivityDto(
    Guid Id,
    string Name,
    string? Description,
    ActivityType Type,
    Priority Priority,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    Guid FeatureId,
    Feature Feature
);