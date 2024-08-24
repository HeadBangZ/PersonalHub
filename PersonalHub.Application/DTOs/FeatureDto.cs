using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateFeatureDto(
    [Required][StringLength(75)] string Name,
    string? Description
);

public record UpdateFeatureDto(
    [Required] Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    List<Activity>? Activities,
    Priority? Importance,
    bool? IsCompleted
);

public record FeatureDto(
    Guid Id,
    [StringLength(75)] string Name,
    string? Description,
    IReadOnlyCollection<Activity> Activities,
    Priority Importance,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
