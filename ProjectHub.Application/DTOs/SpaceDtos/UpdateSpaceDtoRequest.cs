using ProjectHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record UpdateSpaceDtoRequest(
    [Required] Guid Id,
    string? Name,
    string? Description,
    ProgressState? State
);
