namespace ProjectHub.Application.DTOs.ApiUserDtos;

public record AuthDtoResponse(
    string Id,
    string Token,
    string RefreshToken
);