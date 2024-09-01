using PersonalHub.Application.DTOs.SpaceDtos;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Application.Extensions;

public static class SpaceExtensions
{
    public static SpaceDtoResponse MapSpaceToDto(this Space space)
    {
        return new SpaceDtoResponse(
            space.Id.Id,
            space.Name,
            space.Description,
            space.Sections,
            space.State
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
