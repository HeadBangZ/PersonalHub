using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Tests.Unit.Mocks;

public sealed class MockDbContextSingleton
{
    private static readonly MockDbContextSingleton instance = new MockDbContextSingleton();

    private readonly ProjectHubDbContext _context;

    static MockDbContextSingleton() { }

    private MockDbContextSingleton()
    {
        var mockConfiguration = Substitute.For<IConfiguration>();

        var options = new DbContextOptionsBuilder<ProjectHubDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ProjectHubDbContext(options, mockConfiguration);
    }

    public static MockDbContextSingleton Instance
    {
        get
        {
            return instance;
        }
    }

    public ProjectHubDbContext DbContext
    {
        get
        {
            return _context;
        }
    }
}
