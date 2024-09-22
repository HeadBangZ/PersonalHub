using Microsoft.Extensions.Configuration;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Infrastructure.Data.Seeders;

public sealed class SpaceSeeder(ProjectHubDbContext dbContext, IConfiguration configuration) : ISpaceSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Spaces.Any())
            {
                var spaces = GetSpaces();
                dbContext.Spaces.AddRange(spaces);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Space> GetSpaces()
    {
        var name = "Personal Hub";
        var description = "Personal Hub an application used to manage projects";
        var state = ProgressState.InProgress;
        var sections = new List<Section>()
                    {
                        new(){
                            Name = "Backlog",
                            Description = "An accumulation of uncompleted work or matters needing to be dealt with",
                            Epics = [
                                new ()
                                {
                                    AssignedToUserId = configuration["UserAuth:UserId"],
                                    Name = "Epic Story",
                                    Description = "This is gonna be great!",
                                    Features = [
                                        new (Guid.Empty, "Registration", "It should be possible to register a user", [
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
                                            ], Priority.Low, false),
                                        new Feature(Guid.Empty, "Login", "After registration should be able to login", [
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
                                            ], Priority.Low, false)
                                    ]
                                }
                            ]
                        }
                    };



        List<Space> spaces = [
            new(name, description, state)
        ];

        spaces.First().AddSections(sections);

        return spaces;
    }
}
