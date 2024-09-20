using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record SpaceDtoResponse(
    Guid Id,
    string Name,
    string? Description,
    IEnumerable<Section> Sections,
    ProgressState State,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);