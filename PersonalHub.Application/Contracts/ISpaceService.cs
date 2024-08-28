using PersonalHub.Application.DTOs;

namespace PersonalHub.Application.Contracts;

public interface ISpaceService
{
    Task<SpaceDto> AddSpace(CreateSpaceDto spaceDto);
    Task<SpaceDto?> GetSpace(Guid id);
    Task<List<SpaceDto>> GetAllSpaces();
    Task UpdateSpace(Guid id, UpdateSpaceDto spaceDto);
    Task DeleteSpace(Guid id);
}
