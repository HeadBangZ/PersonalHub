using PersonalHub.Application.DTOs.SpaceDtos;

namespace PersonalHub.Application.Contracts;

public interface ISpaceService
{
    Task<SpaceDtoResponse> AddSpace(CreateSpaceDtoRequest request);
    Task<SpaceDtoResponse?> GetSpace(Guid id);
    Task<List<SpaceDtoResponse>> GetAllSpaces();
    Task UpdateSpace(Guid id, UpdateSpaceDtoRequest request);
    Task DeleteSpace(Guid id);
}
