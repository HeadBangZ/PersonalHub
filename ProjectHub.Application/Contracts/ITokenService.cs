using PersonalHub.Application.DTOs.ApiUserDtos;
using PersonalHub.Domain.User.Entities;

namespace PersonalHub.Application.Contracts;

public interface ITokenService
{
    Task<string> GenerateToken(ApiUser user);
    Task<string> CreateRefreshToken(ApiUser user);
    Task<AuthDtoResponse> VerifyRefreshToken(AuthDtoResponse request);
}
