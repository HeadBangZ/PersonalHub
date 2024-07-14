using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Application.Extensions;
using PersonalHub.Application.Contracts;

namespace PersonalHub.Infrastructure.Data.Repositories.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto)
        {
            ApiUser user = createApiUserDto.ToApiUser();

            var result = await _userManager.CreateAsync(user, createApiUserDto.Password);

            // TODO: Add role to use when Roles are created

            return result.Errors;
        }
    }
}
