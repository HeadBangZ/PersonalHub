using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.FeatureDtos;

public record CreateFeatureDtoRequest(
    [Required][StringLength(75)] string Name,
    string? Description
);
