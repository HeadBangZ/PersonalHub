using ProjectHub.Domain.User.ValueObjects;

namespace ProjectHub.Application.DTOs.ApiUserDtos;

public record ApiUserDtoResponse(
    string Id,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
