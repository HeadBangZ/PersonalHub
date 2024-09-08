using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Tests.Unit.Mocks;

public sealed class MockDbContextFactory
{
    public static ProjectHubDbContext CreateDbContext()
    {
        var mockConfiguration = Substitute.For<IConfiguration>();

        var options = new DbContextOptionsBuilder<ProjectHubDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ProjectHubDbContext(options, mockConfiguration);
    }
}
