using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Entities;
using PersonalHub.Infrastructure.Data.Contexts;

namespace PersonalHub.Infrastructure.Data.Seeders.ApiUsers
{
    internal class ApiUserSeeder(PersonalHubDbContext dbContext, IConfiguration configuration) : IApiUserSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Users.Any())
                {
                    var user = GetApiUser();
                    dbContext.Users.Add(user);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private ApiUser GetApiUser()
        {
            var email = configuration["UserAuth:Email"];
            ApiUser apiUser = new()
            {
                Id = configuration["UserAuth:UserId"],
                Information = new()
                {
                    FirstName = configuration["UserAuth:FirstName"],
                    LastName = configuration["UserAuth:LastName"]
                },
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
}