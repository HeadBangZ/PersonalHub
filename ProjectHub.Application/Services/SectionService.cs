using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SectionDtos;

namespace ProjectHub.Application.Services;

public class SectionService : ISectionService
{
    public Task<SectionDtoResponse> AddSectionAsync(CreateSectionDtoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSectionAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SectionDtoResponse>> GetAllSectionAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SectionDtoResponse?> GetSectionAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSectionAsync(Guid id, UpdateSectionDtoRequest request)
    {
        throw new NotImplementedException();
    }
}
