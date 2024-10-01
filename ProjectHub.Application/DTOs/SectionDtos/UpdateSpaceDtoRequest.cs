using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SectionDtos;

public record UpdateSpaceDtoRequest(
    [Required] Guid Id,
    string Name,
    string Description
);
