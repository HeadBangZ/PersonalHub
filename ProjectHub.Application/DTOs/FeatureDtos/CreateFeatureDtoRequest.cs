using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs.FeatureDtos;

public record CreateFeatureDtoRequest(
    [Required][StringLength(75)] string Name,
    string? Description
);
