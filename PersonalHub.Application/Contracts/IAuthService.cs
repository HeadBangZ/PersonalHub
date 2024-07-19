using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Contracts
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> Register(CreateApiUserDto createApiUserDto);
        Task<AuthResponseDto?> AuthenticateUser(LoginApiUserDto loginApiUserDto);
    }
}
