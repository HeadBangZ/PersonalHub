using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record SpaceDtoResponse(
    Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    IReadOnlyCollection<Section>? Sections,
    ProgressState? State,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);