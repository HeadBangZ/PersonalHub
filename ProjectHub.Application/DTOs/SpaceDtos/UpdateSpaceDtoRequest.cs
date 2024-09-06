using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record UpdateSpaceDtoRequest(
    [Required] Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    List<Section>? Sections,
    ProgressState? State
);
