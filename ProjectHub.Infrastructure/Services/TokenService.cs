using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ProjectHub.Application.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Application.DTOs.ApiUserDtos;

namespace ProjectHub.Infrastructure.Services;

public class TokenService : ITokenService
{

    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _durationInMinutes;

    private readonly UserManager<ApiUser> _userManager;
    private const string _loginProvider = "https://localhost:7149/";
    private const string _refreshToken = "RefreshToken";

    public TokenService(string key, string issuer, string audience, int durationInMinutes, UserManager<ApiUser> userManager)
    {
        _key = key;
        _issuer = issuer;
        _audience = audience;
        _durationInMinutes = durationInMinutes;
        _userManager = userManager;
    }

    public async Task<string> GenerateToken(ApiUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        var userClaims = await _userManager.GetClaimsAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_durationInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> CreateRefreshToken(ApiUser user)
    {
        await _userManager.RemoveAuthenticationTokenAsync(user, _loginProvider, _refreshToken);
        var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, _loginProvider, _refreshToken);
        await _userManager.SetAuthenticationTokenAsync(user, _loginProvider, _refreshToken, newRefreshToken);
        return newRefreshToken;
    }

    public async Task<AuthDtoResponse?> VerifyRefreshToken(AuthDtoResponse request)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
        var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

        var user = await _userManager.FindByNameAsync(username);

        if (user == null || user.Id != request.Id)
        {
            return null;
        }

        var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(user, _loginProvider, _refreshToken, request.RefreshToken);

        if (!isValidRefreshToken)
        {
            await _userManager.UpdateSecurityStampAsync(user);
            return null;
        }

        var token = await GenerateToken(user);
        var newRefreshToken = await CreateRefreshToken(user);
        return new AuthDtoResponse
        (
            Id: user.Id,
            Token: token,
            RefreshToken: newRefreshToken
        );
    }
}
