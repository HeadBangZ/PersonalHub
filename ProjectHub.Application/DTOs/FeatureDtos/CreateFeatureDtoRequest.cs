using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.FeatureDtos;

public record CreateFeatureDtoRequest(
    Guid EpicId,
    [Required][StringLength(75)] string Name,
    string? Description
);
