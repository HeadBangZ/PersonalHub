
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.Enums;
using PersonalHub.Infrastructure.Data.Contexts;

namespace PersonalHub.Infrastructure.Data.Seeders;

internal class UserStorySeeder(PersonalHubDbContext dbContext) : IUserStorySeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.UserStories.Any())
            {
                var userStories = GetUserStories();
                dbContext.UserStories.AddRange(userStories);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<UserStory> GetUserStories()
    {
        List<UserStory> stories = [
            new()
            {
                Name = "Registration",
                Description = "It should be possible to register a user",
                Items =
                [
                    new()
                    {
                        Name = "HTML Form",
                        Description = "A form for the user to add information",
                        StoryItemType = ItemType.Task,
                        StoryItemPriority = Priority.Low,
                    },
                    new()
                    {
                        Name = "Style Form",
                        Description = "The HTML form needs to look good",
                        StoryItemType = ItemType.Task,
                        StoryItemPriority = Priority.Low,
                    }
                ],
                CreatedAt = DateTime.Now,
            },
            new()
            {
                Name = "Login",
                Description = "After registration should be able to login",
                Items =
                [
                    new()
                    {
                        Name = "HTML Form",
                        Description = "A form for the user to add information",
                        StoryItemType = ItemType.Task,
                        StoryItemPriority = Priority.Low,
                    },
                    new()
                    {
                        Name = "Style Form",
                        Description = "The HTML form needs to look good",
                        StoryItemType = ItemType.Task,
                        StoryItemPriority = Priority.Low,
                    },
                    new()
                    {
                        Name = "Add JWT Token",
                        Description = "Add token to know who the user is",
                        StoryItemType = ItemType.Task,
                        StoryItemPriority = Priority.High,
                    }
                ],
                CreatedAt = DateTime.Now,
            }
        ];

        return stories;
    }
}


