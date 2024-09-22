using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Tests.Integration.Suite.Mocks;

namespace ProjectHub.Tests.Integration.Suite;

public abstract class ApiIntegrationTestFixture : IAsyncLifetime
{
    private ApiWebApplicationFactory _factory;
    private ProjectHubDbContext _context;

    protected HttpClient HttpClient;

    public async Task InitializeAsync()
    {
        _factory = new ApiWebApplicationFactory();
        _context = _factory.CreateDbContext();
        HttpClient = HttpClientFactory.Create(_factory);

        await Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        if (_context != null)
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.DisposeAsync();
        }

        if (_factory != null)
        {
            _factory.Dispose();
        }

        if (HttpClient != null)
        {
            HttpClient.Dispose();
        }

        await Task.CompletedTask;
    }
}
