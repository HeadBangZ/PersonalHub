using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Workspace.Entities;

namespace PersonalHub.Application.Extensions;

public static class SpaceExtensions
{
    public static SpaceDto MapSpaceToDto(this Space spaceDto)
    {
        return new SpaceDto(
            spaceDto.Id.Id,
            spaceDto.Name,
            spaceDto.Description,
            spaceDto.Sections,
            spaceDto.Status
        );
    }

    public static Space MapCreateDtoToSpace(this CreateSpaceDto createRequest)
    {
        return new Space(
            createRequest.Name,
            createRequest.Description
        );
    }
}
