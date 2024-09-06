using ProjectHub.Domain.User.ValueObjects;

namespace ProjectHub.Application.DTOs.ApiUserDtos;

public record ApiUserDtoResponse(
    string Id,
    PersonalInfo Information,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
