using ProjectHub.Application.DTOs.SectionDtos;

namespace ProjectHub.Application.Contracts;

public interface ISectionService
{
    Task<SectionDtoResponse> AddSectionAsync(CreateSectionDtoRequest request);
    Task<SectionDtoResponse?> GetSectionAsync(Guid id);
    Task<List<SectionDtoResponse>> GetAllSectionAsync();
    Task UpdateSectionAsync(Guid id, UpdateSectionDtoRequest request);
    Task DeleteSectionAsync(Guid id);
}
