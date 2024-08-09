using PersonalHub.Domain.User.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Application.DTOs;

public record ApiUserDto(
    string Id,
    PersonalInfo Information,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

public record CreateApiUserDto(
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(75)] string LastName,
    [Required][EmailAddress] string Email,
    [Required][DataType(DataType.Password)] string Password
);

public record LoginApiUserDto(
    [Required] string Email,
    [Required] string Password
);

public record AuthResponseDto(
    string Id,
    string Token,
    string RefreshToken
);
