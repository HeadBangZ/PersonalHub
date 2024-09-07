using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.FeatureDtos;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Application.Extensions;
using ProjectHub.Application.Shared;
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

    public async Task<SpaceDtoResponse> AddSpace(CreateSpaceDtoRequest spaceDto)
    {
        var space = spaceDto.MapCreateDtoToSpace();

        await _spaceRepository.AddAsync(space);
        return space.MapSpaceToDto();
    }

    public async Task<List<SpaceDtoResponse>> GetAllSpaces()
    {
        var spaceDtos = new List<SpaceDtoResponse>();
        var spaces = await _spaceRepository.GetAllAsync();

        foreach (var space in spaces)
        {
            spaceDtos.Add(space.MapSpaceToDto());
        }

        return spaceDtos;
    }

    public async Task<SpaceDtoResponse?> GetSpace(Guid id)
    {
        var space = await _spaceRepository.GetAsync(new SpaceId(id));

        if (space == null)
        {
            return null;
        }

        var spaceDto = space.MapSpaceToDto();

        return spaceDto;
    }

    public async Task DeleteSpace(Guid id)
    {
        await _spaceRepository.DeleteAsync(new SpaceId(id));
    }

    public async Task UpdateSpace(Guid id, UpdateSpaceDtoRequest request)
    {
        var existingSpace = await _spaceRepository.GetAsync(new SpaceId(id));

        if (existingSpace == null)
        {
            throw new Exception($"Space with ID - {id} was not found");
        }

        var changes = DeltaFinder.GetChangedProperties(request, existingSpace);

        existingSpace.ApplyChanges<Space>(changes);

        await _spaceRepository.UpdateAsync(existingSpace);
    }
}
