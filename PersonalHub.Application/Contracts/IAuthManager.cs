using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;

namespace PersonalHub.Application.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto);
    }
}
