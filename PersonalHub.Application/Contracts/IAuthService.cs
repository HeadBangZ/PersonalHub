using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs.ApiUserDtos;

namespace PersonalHub.Application.Contracts;

public interface IAuthService
{
    Task<IEnumerable<IdentityError>> Register(CreateApiUserDtoRequest request);
    Task<AuthDtoResponse?> AuthenticateUser(LoginDtoRequest loginRequest);
    Task<AuthDtoResponse> VerifyRefreshToken(AuthDtoResponse request);
}
