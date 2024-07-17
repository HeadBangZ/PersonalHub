using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;

namespace PersonalHub.Application.Contracts
{
    public interface ITokenService
    {
        Task<string> GenerateToken();
        Task<string> RefreshToken(ApiUser user);
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
