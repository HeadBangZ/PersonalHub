using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Infrastructure.Data.Repositories.Auth;

namespace PersonalHub.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto)
        {
            var user = createApiUserDto.ToApiUser();
            user.UserName = createApiUserDto.Email;

            return await _authRepository.Register(user, createApiUserDto.Password);
        }
    }
}
