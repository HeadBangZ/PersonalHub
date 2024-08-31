﻿using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs.SpaceDtos;
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

    public Task UpdateSpace(Guid id, UpdateSpaceDtoRequest request)
    {
        throw new NotImplementedException();
    }
}
