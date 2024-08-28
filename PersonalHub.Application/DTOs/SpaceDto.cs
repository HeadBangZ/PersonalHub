using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record CreateSpaceDto(
    [Required][StringLength(75)] string Name,
    [Required] string Description
);

public record UpdateSpaceDto(
    [Required] Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    List<Section>? Sections,
    ProgressStatus? Status
);

public record SpaceDto(
    Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    IReadOnlyCollection<Section>? Sections,
    ProgressStatus? Status
);
