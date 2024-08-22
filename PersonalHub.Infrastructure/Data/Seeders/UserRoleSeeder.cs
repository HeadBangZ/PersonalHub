using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;
using PersonalHub.Infrastructure.Data.Contexts;

namespace PersonalHub.Infrastructure.Data.Seeders;

public sealed class UserRoleSeeder(PersonalHubDbContext dbContext, IConfiguration configuration) : IUserRoleSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.UserRoles.Any())
            {
                var userRoles = GetUserRoles();
                dbContext.UserRoles.AddRange(userRoles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityUserRole<string>> GetUserRoles()
    {
        List<IdentityUserRole<string>> userRoles = [
            new()
            {
                UserId = configuration["UserAuth:UserId"],
                RoleId = configuration["UserAuth:RoleId"]
            }
        ];

        return userRoles;
    }
}


