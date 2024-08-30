using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.Workspace.ValueObjects;

namespace PersonalHub.Application.Services;

public class SpaceService : ISpaceService
{
    private readonly ISpaceRepository _spaceRepository;
    public SpaceService(ISpaceRepository spaceRepository)
    {
        _spaceRepository = spaceRepository;
    }

    public async Task<SpaceDto> AddSpace(CreateSpaceDto spaceDto)
    {
        var space = spaceDto.MapCreateDtoToSpace();

        await _spaceRepository.AddAsync(space);
        return space.MapSpaceToDto();
    }

    public Task DeleteSpace(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SpaceDto>> GetAllSpaces()
    {
        var spaceDtos = new List<SpaceDto>();
        var spaces = await _spaceRepository.GetAllAsync();

        foreach (var space in spaces)
        {
            spaceDtos.Add(space.MapSpaceToDto());
        }

        return spaceDtos;
    }

    public async Task<SpaceDto?> GetSpace(Guid id)
    {
        var space = await _spaceRepository.GetAsync(new SpaceId(id));

        if (space == null)
        {
            return null;
        }

        var spaceDto = space.MapSpaceToDto();

        return spaceDto;
    }

    public Task UpdateSpace(Guid id, UpdateSpaceDto spaceDto)
    {
        throw new NotImplementedException();
    }
}
