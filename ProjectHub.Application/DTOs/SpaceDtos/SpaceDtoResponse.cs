using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record SpaceDtoResponse(
    Guid Id,
    string Name,
    string? Description,
    IReadOnlyCollection<Section> Sections,
    ProgressState State,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);