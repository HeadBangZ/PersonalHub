using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Extensions
{
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

        public static ApiUser ToApiUser(this ApiUserDto apiUserDto)
        {
            return new ApiUser
            {
                FirstName = apiUserDto.FirstName,
                LastName = apiUserDto.LastName,
                Email = apiUserDto.Email,
                CreatedAt = apiUserDto.CreatedAt,
                UpdatedAt = apiUserDto.UpdatedAt,
            };
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
}
