using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Domain.Workspace.ValueObjects;
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


