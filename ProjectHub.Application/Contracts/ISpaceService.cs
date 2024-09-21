using ProjectHub.Application.DTOs.SpaceDtos;

namespace ProjectHub.Application.Contracts;

public interface ISpaceService
{
    Task<SpaceDtoResponse> AddSpaceAsync(CreateSpaceDtoRequest request);
    Task<SpaceDtoResponse?> GetSpaceAsync(Guid id);
    Task<List<SpaceDtoResponse>> GetAllSpacesAsync();
    Task<bool> UpdateSpaceAsync(Guid id, UpdateSpaceDtoRequest request);
    Task DeleteSpaceAsync(Guid id);
}
