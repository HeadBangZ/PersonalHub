using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateActivityDto(
    [Required][StringLength(75)] string Name,
    string? Description,
    Guid FeatureId,
    Priority? Priority = null
);

public record ActivityDto(
    [Required] Guid Id,
    [StringLength(75)] string Name,
    string? Description,
    Priority Priority,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    [Required] Guid FeatureId
);