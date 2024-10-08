﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Data.Seeders;

public sealed class UserRoleSeeder(ProjectHubDbContext dbContext, IConfiguration configuration) : IUserRoleSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.UserRoles.Any())
            {
                var userRoles = await GetUserRoles();
                dbContext.UserRoles.AddRange(userRoles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private async Task<IEnumerable<IdentityUserRole<string>>> GetUserRoles()
    {
        var userRoles = new List<IdentityUserRole<string>>();

        var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.NormalizedName == "OWNER");

        if (role != null)
        {
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = configuration["UserAuth:UserId"],
                RoleId = role.Id,
            });
        }

        return userRoles;
    }
}


