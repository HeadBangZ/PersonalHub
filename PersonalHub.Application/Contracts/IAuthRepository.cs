using Microsoft.AspNetCore.Identity;
using PersonalHub.Application.DTOs;
using PersonalHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Infrastructure.Data.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityError>> Register(ApiUser user, string password);
        Task<ApiUser> FindUserByEmail(string email);
    }
}
