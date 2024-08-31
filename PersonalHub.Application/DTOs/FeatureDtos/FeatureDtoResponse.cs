using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs.FeatureDtos;

public record FeatureDtoResponse(
    Guid Id,
    [StringLength(75)] string Name,
    string? Description,
    IReadOnlyCollection<Activity> Activities,
    Priority Importance,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
