using ProjectHub.Domain.User.Entities;

namespace ProjectHub.Infrastructure.Data.Seeders.ApiUsers;

public interface IUserProfileSeeder
{
    Task Seed(ApiUser user);
}
