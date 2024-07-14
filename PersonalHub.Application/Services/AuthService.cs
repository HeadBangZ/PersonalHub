using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;

namespace PersonalHub.Application.Services
{
    public class AuthService
    {
        private readonly IAuthManager _authManager;

        public AuthService(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto)
        {
            return await _authManager.Register(createApiUserDto);
        }
    }
}
