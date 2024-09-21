using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Mappers;
using ProjectHub.Application.Utils;
using ProjectHub.Domain.Contracts;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Application.Services;

public class SpaceService : ISpaceService
{
    private readonly ISpaceRepository _spaceRepository;
    public SpaceService(ISpaceRepository spaceRepository)
    {
        _spaceRepository = spaceRepository;
    }

    public async Task<SpaceDtoResponse> AddSpaceAsync(CreateSpaceDtoRequest spaceDto)
    {
        var space = spaceDto.MapCreateDtoToSpace();

        await _spaceRepository.AddAsync(space);
        return space.MapSpaceToDto();
    }

    public async Task<List<SpaceDtoResponse>> GetAllSpacesAsync()
    {
        var spaceDtos = new List<SpaceDtoResponse>();
        var spaces = await _spaceRepository.GetAllAsync();

        foreach (var space in spaces)
        {
            spaceDtos.Add(space.MapSpaceToDto());
        }

        return spaceDtos;
    }

    public async Task<SpaceDtoResponse?> GetSpaceAsync(Guid id)
    {
        var space = await _spaceRepository.GetAsync(new SpaceId(id));

        if (space == null)
        {
            return null;
        }

        var spaceDto = space.MapSpaceToDto();

        return spaceDto;
    }

    public async Task DeleteSpaceAsync(Guid id)
    {
        await _spaceRepository.DeleteAsync(new SpaceId(id));
    }

    public async Task<bool> UpdateSpaceAsync(Guid id, UpdateSpaceDtoRequest request)
    {
        var existingSpace = await _spaceRepository.GetAsync(new SpaceId(id));

        if (existingSpace == null)
        {
            return false;
        }

        var changes = DeltaFinder.GetChangedProperties(request, existingSpace);
        var properties = DeltaFinder.GetPropertyDictionary<Space>();

        existingSpace.ApplyChanges<Space>(changes, properties);

        await _spaceRepository.UpdateAsync(existingSpace);

        return true;
    }
}
