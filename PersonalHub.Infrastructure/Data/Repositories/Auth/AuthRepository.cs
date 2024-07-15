using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Application.Extensions;
using PersonalHub.Application.Contracts;

namespace PersonalHub.Infrastructure.Data.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApiUser> _userManager;

        public AuthRepository(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Errors;
        }
    }
}
