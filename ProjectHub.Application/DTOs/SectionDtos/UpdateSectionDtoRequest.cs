using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SectionDtos;

public record UpdateSectionDtoRequest(
    [Required] Guid Id,
    string Name,
    string Description
);
