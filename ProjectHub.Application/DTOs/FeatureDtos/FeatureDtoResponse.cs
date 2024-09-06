using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.FeatureDtos;

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
