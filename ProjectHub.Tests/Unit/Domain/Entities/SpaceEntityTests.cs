using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Domain.Workspace.Enums;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Tests.Unit.Mocks;

namespace ProjectHub.Tests.Unit.Domain.Entities;

public class SpaceEntityTests : IAsyncLifetime
{
    private readonly ProjectHubDbContext _context;

    public SpaceEntityTests()
    {
        _context = MockDbContextFactory.CreateDbContext();
    }

    private async Task SeedDataAsync()
    {
        var spaces = new List<Space>()
            {
                new Space("Project Hub", "Description Space 1", ProgressState.Completed, new List<Section>()),
                new Space("Space 2", "Description Space 2", ProgressState.NotStarted, new List<Section>()),
                new Space("Space 3", "Description Space 3", ProgressState.InProgress, new List<Section>()),
                new Space("Document Management", "Description Space 4", ProgressState.NotStarted, new List<Section>()),
            };

        await _context.Spaces.AddRangeAsync(spaces);
        await _context.SaveChangesAsync();
    }

    public async Task InitializeAsync()
    {
        await SeedDataAsync();
    }

    public async Task DisposeAsync()
    {
        _context.Spaces.RemoveRange(_context.Spaces);
        await _context.SaveChangesAsync();
    }

    [Fact]
    public void SpaceCountTest()
    {
        int expected = 4;

        int actual = _context.Spaces.Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FirstItemIsProjectHubTest()
    {
        string expected = "Project Hub";

        Space? space = _context.Spaces.FirstOrDefault();

        Assert.NotNull(space);
        Assert.Equal(expected, space.Name);
    }

    [Fact]
    public void LastItemIsDocumentManagementTest()
    {
        string expected = "Document Management";

        Space? space = _context.Spaces.LastOrDefault();

        Assert.NotNull(space);
        Assert.Equal(expected, space.Name);
    }

    [Fact]
    public void NoSpacesInDbTest()
    {
        ProjectHubDbContext db = MockDbContextFactory.CreateDbContext();

        var spaces = db.Spaces;

        Assert.Empty(spaces);
    }
}


