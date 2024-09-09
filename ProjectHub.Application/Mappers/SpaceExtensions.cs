using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Domain.Workspace.Entities;

namespace ProjectHub.Application.Mappers;

public static class SpaceExtensions
{
    public static SpaceDtoResponse MapSpaceToDto(this Space space)
    {
        return new SpaceDtoResponse(
            space.Id.Id,
            space.Name,
            space.Description,
            space.Sections,
            space.State,
            space.CreatedAt,
            space.ModifiedAt
        );
    }

    public static Space MapCreateDtoToSpace(this CreateSpaceDtoRequest request)
    {
        return new Space(
            request.Name,
            request.Description
        );
    }
}
