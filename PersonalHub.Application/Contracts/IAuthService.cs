using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;

namespace PersonalHub.Application.Contracts;

public interface IAuthService
{
    Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto);
    Task<AuthResponseDto?> AuthenticateUser(LoginApiUserDto loginApiUserDto);
}
