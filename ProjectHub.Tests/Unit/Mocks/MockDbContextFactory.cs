using Microsoft.EntityFrameworkCore;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Tests.Unit.Mocks;

public sealed class MockDbContextFactory
{
    public static ProjectHubDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ProjectHubDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ProjectHubDbContext(options);
    }
}
