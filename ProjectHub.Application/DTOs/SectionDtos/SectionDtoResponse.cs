using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Application.DTOs.SectionDtos;

public record SectionDtoResponse(
    Guid Id,
    Guid SpaceId,
    string Name,
    string Description,
    List<Epic> Epics,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);

