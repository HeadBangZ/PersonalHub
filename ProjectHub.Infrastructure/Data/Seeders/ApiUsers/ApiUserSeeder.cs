using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Data.Seeders.ApiUsers;

public sealed class ApiUserSeeder(ProjectHubDbContext dbContext, IConfiguration configuration) : IApiUserSeeder
{
    public async Task<ApiUser> Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Users.Any())
            {
                var user = GetApiUser();
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
                return user;
            }
        }

        return dbContext.Users.FirstOrDefault();
    }

    private ApiUser GetApiUser()
    {
        var email = configuration["UserAuth:Email"];
        ApiUser apiUser = new()
        {
            Id = configuration["UserAuth:UserId"],
            Email = email,
            EmailConfirmed = true,
            NormalizedEmail = email.ToUpper(),
            NormalizedUserName = email.ToUpper(),
        };

        PasswordHasher<ApiUser> ph = new PasswordHasher<ApiUser>();
        apiUser.PasswordHash = ph.HashPassword(apiUser, configuration["UserAuth:Pwd"]);

        return apiUser;
    }
}