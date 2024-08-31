using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs.SpaceDtos;

public record SpaceDtoResponse(
    Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    IReadOnlyCollection<Section>? Sections,
    ProgressStatus? Status
);