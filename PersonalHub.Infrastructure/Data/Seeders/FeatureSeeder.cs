using PersonalHub.Domain.Workspace.Entities;
using PersonalHub.Domain.Workspace.Enums;
using PersonalHub.Infrastructure.Data.Contexts;

namespace PersonalHub.Infrastructure.Data.Seeders;

public sealed class FeatureSeeder(PersonalHubDbContext dbContext) : IFeatureSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Features.Any())
            {
                var features = GetFeatures();
                dbContext.Features.AddRange(features);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Feature> GetFeatures()
    {
        List<Feature> features = [
            new()
            {
                Name = "Registration",
                Description = "It should be possible to register a user",
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
                    }
                ],
                Importance = Priority.Low,
                CreatedAt = DateTime.Now,
            },
            new()
            {
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
        ];

        return features;
    }
}


