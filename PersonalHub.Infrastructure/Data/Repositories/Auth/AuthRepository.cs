using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using PersonalHub.Application.Extensions;
using PersonalHub.Application.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace PersonalHub.Infrastructure.Data.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApiUser> _userManager;

        public AuthRepository(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Owner");
            }

            return result.Errors;
        }

        public async Task<ApiUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> ValidateCredentials(ApiUser user, string password)
        {
            bool isValidCredentials = await _userManager.CheckPasswordAsync(user, password);

            if (!isValidCredentials)
            {
                return default;
            }

            return isValidCredentials;
        }
    }
}
