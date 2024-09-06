using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.FeatureDtos;

public record UpdateFeatureDtoRequest(
    [Required] Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    List<Activity>? Activities,
    Priority? Importance,
    bool? IsCompleted
);
