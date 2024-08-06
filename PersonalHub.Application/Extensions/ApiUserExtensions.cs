using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
namespace PersonalHub.Application.Extensions;

public static class ApiUserExtensions
{
    public static ApiUserDto ToApiUserDto(this ApiUser apiUser)
    {
        return new ApiUserDto(
            apiUser.Id,
            apiUser.FirstName,
            apiUser.LastName,
            apiUser.Email,
            apiUser.CreatedAt,
            apiUser.UpdatedAt
        );
    }

    public static ApiUser ToApiUser(this CreateApiUserDto createApiUserDto)
    {
        return new ApiUser
        {
            FirstName = createApiUserDto.FirstName,
            LastName = createApiUserDto.LastName,
            Email = createApiUserDto.Email,
            UserName = createApiUserDto.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
        };
    }
}
