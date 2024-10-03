using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SectionDtos;
using ProjectHub.Application.Mappers;
using ProjectHub.Domain.Contracts;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Application.Services;

public class SectionService : ISectionService
{
    private readonly ISectionRepository _sectionRepository;

    public SectionService(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

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

    public async Task<SectionDtoResponse?> GetSectionAsync(Guid id)
    {
        var section = await _sectionRepository.GetAsync(new SectionId(id));

        if (section == null)
        {
            return null;
        }

        var sectionDto = section.MapSectionToDto();

        return sectionDto;
    }

    public Task UpdateSectionAsync(Guid id, UpdateSectionDtoRequest request)
    {
        throw new NotImplementedException();
    }
}
