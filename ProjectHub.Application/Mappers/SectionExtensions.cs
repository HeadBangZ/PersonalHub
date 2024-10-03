using ProjectHub.Application.DTOs.SectionDtos;
using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Application.Mappers;

public static class SectionExtensions
{
    public static SectionDtoResponse MapSectionToDto(this Section section)
    {
        return new SectionDtoResponse(
            section.Id.Id,
            section.SpaceId.Id,
            section.Name,
            section.Description,
            section.Epics,
            section.CreatedAt,
            section.ModifiedAt
        );
    }

    public static Section MapCreateDtoToSection(this Section request)
    {
        return new Section(
            request.Name,
            request.Description
        );
    }
}
