using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs.SpaceDtos;

public record UpdateSpaceDtoRequest(
    [Required] Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    List<Section>? Sections,
    ProgressStatus? Status
);
