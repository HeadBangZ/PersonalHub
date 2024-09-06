using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.SpaceDtos;

public record CreateSpaceDtoRequest(
    [Required][StringLength(75)] string Name,
    [Required] string Description
);
