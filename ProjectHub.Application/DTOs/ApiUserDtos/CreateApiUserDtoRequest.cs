using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Application.DTOs.ApiUserDtos;

public record CreateApiUserDtoRequest(
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(75)] string LastName,
    [Required][EmailAddress] string Email,
    [Required][DataType(DataType.Password)] string Password
);
