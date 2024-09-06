using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Application.Extensions;

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

    public static Space MapDtoToSpace(this UpdateSpaceDtoRequest request, Space existingSpace)
    {
        if (!string.IsNullOrEmpty(request.Name))
        {
            existingSpace.Name = request.Name;
        }

        if (!string.IsNullOrEmpty(request.Description))
        {
            existingSpace.Description = request.Description;
        }

        if (request.Sections != null)
        {
            existingSpace.Sections = request.Sections;
        }

        if (request.State.HasValue)
        {
            existingSpace.State = request.State.Value;
        }

        return existingSpace;
    }
}
