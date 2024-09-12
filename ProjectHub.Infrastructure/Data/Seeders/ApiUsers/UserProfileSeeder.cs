using Microsoft.Extensions.Configuration;
using ProjectHub.Domain.User.Entities;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Data.Seeders.ApiUsers;

public class UserProfileSeeder(ProjectHubDbContext dbContext, IConfiguration configuration) : IUserProfileSeeder
{
    public async Task Seed(ApiUser user)
    {
        if (user == null)
        {
            return;
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.UserProfiles.Any())
            {
                var userProfile = GetUserProfiles();
                dbContext.UserProfiles.Add(userProfile);
                await dbContext.SaveChangesAsync();

                user.UserProfileId = userProfile.Id;
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private UserProfile GetUserProfiles()
    {
        UserProfile userProfile = new()
        {
            ApiUserId = configuration["UserAuth:UserId"],
            Information = new()
            {
                FirstName = "Thomas",
                LastName = "Hermansen",
                DateOfBirth = new DateTime(1990, 11, 09)
            },
            AddressInfo = new()
            {
                Country = "Denmark",
                CountryCode = "DK",
                City = "Copenhagen"
            }
        };

        return userProfile;
    }
}
