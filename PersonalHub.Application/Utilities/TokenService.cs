using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PersonalHub.Application.Contracts;
using PersonalHub.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace PersonalHub.Application.Utilities
{
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

        public async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddMinutes(_durationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> RefreshToken(ApiUser user)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, _loginProvider, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(user, _loginProvider, _refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        public Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            throw new NotImplementedException();

        }
    }
}
