using Microsoft.AspNetCore.Identity;
using PersonalHub.Domain.User.Entities;

namespace PersonalHub.Domain.User.Repositories;

public interface IAuthRepository
{
    Task<ApiUser> FindUserByEmail(string email);
    Task<IEnumerable<IdentityError>> Register(ApiUser user, string password);
    Task<bool> ValidateCredentials(ApiUser user, string password);
}
