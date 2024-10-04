using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.SectionDtos;
using ProjectHub.Application.Mappers;
using ProjectHub.Domain.Contracts;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.ValueObjects;

namespace ProjectHub.Application.Services;

public class SectionService : ISectionService
{
    private readonly ISectionRepository _sectionRepository;
    private readonly IEntityExistenceVerfifier<Space, SpaceId> _existenceVerifier;
    public SectionService(ISectionRepository sectionRepository, IEntityExistenceVerfifier<Space, SpaceId> existenceVerifier)
    {
        _sectionRepository = sectionRepository;
        _existenceVerifier = existenceVerifier;
    }

    public async Task<SectionDtoResponse?> AddSectionAsync(CreateSectionDtoRequest request)
    {
        var spaceId = new SpaceId(request.SpaceId);

        if (!await _existenceVerifier.ExistsAsync(spaceId))
        {
            return null;
        }

        var section = request.MapCreateDtoToSection();
        section.SetSpaceId(spaceId);

        await _sectionRepository.AddAsync(section);

        return section.MapSectionToDto();
    }

    public Task DeleteSectionAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SectionDtoResponse>> GetAllSectionAsync()
    {
        var sectionDtos = new List<SectionDtoResponse>();
        var sections = await _sectionRepository.GetAllAsync();

        foreach (var section in sections)
        {
            sectionDtos.Add(section.MapSectionToDto());
        }

        return sectionDtos;
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
