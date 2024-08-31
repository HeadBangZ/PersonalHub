﻿using PersonalHub.Application.DTOs.ApiUserDtos;
using PersonalHub.Domain.User.Entities;

namespace PersonalHub.Application.Extensions;

public static class ApiUserExtensions
{
    public static ApiUserDtoResponse ToApiUserDto(this ApiUser apiUser)
    {
        return new ApiUserDtoResponse(
            apiUser.Id,
            apiUser.Information,
            apiUser.Email,
            apiUser.CreatedAt,
            apiUser.UpdatedAt
        );
    }

    public static ApiUser ToApiUser(this CreateApiUserDtoRequest request)
    {
        return new ApiUser
        {
            Information = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            },
            Email = request.Email,
            UserName = request.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
        };
    }
}
