using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs.FeatureDtos;

public record UpdateFeatureDtoRequest(
    [Required] Guid Id,
    [StringLength(75)] string? Name,
    string? Description,
    List<Activity>? Activities,
    Priority? Importance,
    bool? IsCompleted
);
