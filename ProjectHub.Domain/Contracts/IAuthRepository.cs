using Microsoft.AspNetCore.Identity;
using ProjectHub.Domain.User.Entities;

namespace ProjectHub.Domain.Contracts;

public interface IAuthRepository
{
    Task<ApiUser> FindUserByEmail(string email);
    Task<IEnumerable<IdentityError>> Register(ApiUser user, string password);
    Task<bool> ValidateCredentials(ApiUser user, string password);
}
