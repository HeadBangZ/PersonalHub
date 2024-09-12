using ProjectHub.Application.DTOs.ApiUserDtos;
using ProjectHub.Domain.User.Entities;

namespace ProjectHub.Application.Mappers;

public static class ApiUserExtensions
{
    public static ApiUserDtoResponse ToApiUserDto(this ApiUser apiUser)
    {
        return new ApiUserDtoResponse(
            apiUser.Id,
            apiUser.Email,
            apiUser.CreatedAt,
            apiUser.UpdatedAt
        );
    }

    public static ApiUser ToApiUser(this CreateApiUserDtoRequest request)
    {
        return new ApiUser
        {
            Email = request.Email,
            UserName = request.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
        };
    }
}
