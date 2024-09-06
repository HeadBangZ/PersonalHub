using Microsoft.AspNetCore.Identity;
using ProjectHub.Application.Contracts;
using ProjectHub.Application.DTOs.ApiUserDtos;
using ProjectHub.Application.Extensions;
using ProjectHub.Domain.Contracts;

namespace ProjectHub.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly ITokenService _tokenGenerator;

    public AuthService(IAuthRepository authRepository, ITokenService tokenGenerator)
    {
        _authRepository = authRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthDtoResponse?> AuthenticateUser(LoginDtoRequest loginRequest)
    {
        var user = await _authRepository.FindUserByEmail(loginRequest.Email);
        if (user == null)
        {
            return null;
        }

        bool isValidCredentials = await _authRepository.ValidateCredentials(user, loginRequest.Password);

        if (!isValidCredentials)
        {
            return default;
        }

        string token = await _tokenGenerator.GenerateToken(user);
        var refreshToken = await _tokenGenerator.CreateRefreshToken(user);

        return new AuthDtoResponse
        (
            Id: user.Id,
            Token: token,
            RefreshToken: refreshToken
        );
    }

    public async Task<IEnumerable<IdentityError>> Register(CreateApiUserDtoRequest request)
    {
        var user = request.ToApiUser();
        user.UserName = request.Email;

        return await _authRepository.Register(user, request.Password);
    }

    public async Task<AuthDtoResponse> VerifyRefreshToken(AuthDtoResponse request)
    {
        return await _tokenGenerator.VerifyRefreshToken(request);
    }
}
