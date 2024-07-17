using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;
using PersonalHub.Application.Utilities;
using PersonalHub.Domain.Entities;
using PersonalHub.Infrastructure.Data.Repositories.Auth;
using System.Text;

namespace PersonalHub.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly TokenService _tokenGenerator;

        public AuthService(IAuthRepository authRepository, TokenService tokenGenerator)
        {
            _authRepository = authRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResponseDto?> AuthenticateUser(LoginApiUserDto loginApiUserDto)
        {
            var user = await _authRepository.FindUserByEmail(loginApiUserDto.Email);
            if (user == null)
            {
                return null;
            }

            bool isValidCredentials = await _authRepository.ValidateCredentials(user, loginApiUserDto.Password);

            if (!isValidCredentials)
            {
                return default;
            }

            string token = await _tokenGenerator.GenerateToken();

            return new AuthResponseDto(user.Id, token);
        }

        public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto)
        {
            var user = createApiUserDto.ToApiUser();
            user.UserName = createApiUserDto.Email;

            return await _authRepository.Register(user, createApiUserDto.Password);
        }
    }
}
