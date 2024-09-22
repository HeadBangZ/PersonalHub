using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Data.Seeders
{
    public class RoleSeeder(ProjectHubDbContext dbContext) : IRoleSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Roles.Any())
                {
                    var roles = await GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            var roles = new List<IdentityRole>();
            var role1 = new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            };

            var role2 = new IdentityRole
            {
                Name = "Owner",
                NormalizedName = "OWNER"
            };

            roles.Add(role1);
            roles.Add(role2);

            return roles;
        }
    }
}
