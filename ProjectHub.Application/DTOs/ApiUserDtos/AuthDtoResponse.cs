namespace PersonalHub.Application.DTOs.ApiUserDtos;

public record AuthDtoResponse(
    string Id,
    string Token,
    string RefreshToken
);