using PersonalHub.Domain.User.ValueObjects;

namespace PersonalHub.Application.DTOs.ApiUserDtos;

public record ApiUserDtoResponse(
    string Id,
    PersonalInfo Information,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
