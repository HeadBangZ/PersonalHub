using Microsoft.AspNetCore.Identity;
using PersonalHub.Domain.Contracts;
using PersonalHub.Domain.User.Entities;

namespace PersonalHub.Infrastructure.Repositories.Auth;

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
            await _userManager.AddToRoleAsync(user, "User");
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
