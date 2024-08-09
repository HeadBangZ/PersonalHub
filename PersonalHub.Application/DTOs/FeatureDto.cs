using PersonalHub.Domain.Workspace.Entities;
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
    List<Activity> Items,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

public record UpdateFeatureDto(
    string? Name,
    string? Description
);