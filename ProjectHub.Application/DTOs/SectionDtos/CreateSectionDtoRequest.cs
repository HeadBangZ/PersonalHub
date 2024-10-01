namespace ProjectHub.Application.DTOs.SectionDtos;

public record CreateSectionDtoRequest(
    Guid SpaceId,
    string Name,
    string Description
);

