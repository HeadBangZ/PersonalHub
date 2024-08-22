using Microsoft.Extensions.Configuration;
using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Domain.Workspace.ValueObjects;
using PersonalHub.Infrastructure.Data.Contexts;

namespace PersonalHub.Infrastructure.Data.Seeders;

public sealed class EpicSeeder(PersonalHubDbContext dbContext, IConfiguration configuration) : IEpicSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Epics.Any())
            {
                var epics = GetEpics();
                dbContext.Epics.AddRange(epics);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Epic> GetEpics()
    {
        List<Epic> epics = [
            new()
            {
                AssignedToUserId = configuration["UserAuth:UserId"],
                Name = "Epic Story",
                Description = "This is gonna be great!",
                Features = [
                    new ()
                    {
                        EpicId = EpicId.Empty,
                        Name = "Registration",
                        Description = "It should be possible to register a user",
                        Activities =
                        [
                            new ()
                            {
                                Name = "HTML Form",
                                Description = "A form for the user to add information",
                            },
                            new()
                            {
                                Name = "Style Form",
                                Description = "The HTML form needs to look good",
                            }
                        ],
                        Importance = Priority.Low,
                        CreatedAt = DateTime.Now,
                    },
                    new()
                    {
                        EpicId = EpicId.Empty,
                        Name = "Login",
                        Description = "After registration should be able to login",
                        Activities =
                        [
                            new()
                            {
                                Name = "HTML Form",
                                Description = "A form for the user to add information",
                            },
                            new()
                            {
                                Name = "Style Form",
                                Description = "The HTML form needs to look good",
                            },
                            new()
                            {
                                Name = "Add JWT Token",
                                Description = "Add token to know who the user is",
                            }
                        ],
                        Importance = Priority.Low,
                        CreatedAt = DateTime.Now,
                    }
                ]
            }
        ];

        return epics;
    }
}


