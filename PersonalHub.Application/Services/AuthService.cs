using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Domain.Entities;
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

        public async Task<bool> AuthenticateUser(LoginApiUserDto loginApiUserDto)
        {
            var user = await _authRepository.FindUserByEmail(loginApiUserDto.Email);
            if (user == null)
            {
                return default;
            }

            bool isValidCredentials = await _authRepository.ValidateCredentials(user, loginApiUserDto.Password);

            if (!isValidCredentials)
            {
                return default;
            }

            return isValidCredentials;
        }

        public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto)
        {
            var user = createApiUserDto.ToApiUser();
            user.UserName = createApiUserDto.Email;

            return await _authRepository.Register(user, createApiUserDto.Password);
        }
    }
}
