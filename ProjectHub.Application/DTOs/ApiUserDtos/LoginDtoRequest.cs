using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.ApiUserDtos;

public record LoginDtoRequest(
    [Required] string Email,
    [Required] string Password
);
