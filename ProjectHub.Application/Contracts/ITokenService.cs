using ProjectHub.Application.DTOs.ApiUserDtos;
using ProjectHub.Domain.User.Entities;

namespace ProjectHub.Application.Contracts;

public interface ITokenService
{
    Task<string> GenerateToken(ApiUser user);
    Task<string> CreateRefreshToken(ApiUser user);
    Task<AuthDtoResponse> VerifyRefreshToken(AuthDtoResponse request);
}
