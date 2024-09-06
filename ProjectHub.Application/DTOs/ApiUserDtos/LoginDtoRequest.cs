using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs.ApiUserDtos;

public record LoginDtoRequest(
    [Required] string Email,
    [Required] string Password
);
