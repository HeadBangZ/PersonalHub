using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace PersonalHub.Application.Utilities
{
    public class JwtTokenGenerator
    {

        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _durationInMinutes;

        public JwtTokenGenerator(string key, string issuer, string audience, int durationInMinutes)
        {
            _key = key;
            _issuer = issuer;
            _audience = audience;
            _durationInMinutes = durationInMinutes;
        }

        public async Task<string> GenerateToken(ApiUser user)
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
    }
}
