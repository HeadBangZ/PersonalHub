using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Extensions;

namespace PersonalHub.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenGenerator;

        public AuthService(IAuthRepository authRepository, ITokenService tokenGenerator)
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

            string token = await _tokenGenerator.GenerateToken(user);
            var refreshToken = await _tokenGenerator.CreateRefreshToken(user);

            return new AuthResponseDto
            (
                Id: user.Id,
                Token: token,
                RefreshToken: refreshToken
            );
        }

        public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto)
        {
            var user = createApiUserDto.ToApiUser();
            user.UserName = createApiUserDto.Email;

            return await _authRepository.Register(user, createApiUserDto.Password);
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            return await _tokenGenerator.VerifyRefreshToken(request);
        }
    }
}
