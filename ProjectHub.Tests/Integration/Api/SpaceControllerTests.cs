using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Tests.Integration.Suite.Mocks;
using System.Net;
using System.Text;

namespace ProjectHub.Tests.Integration.Api;

public class SpaceControllerTests : IDisposable
{
    private ApiWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public SpaceControllerTests()
    {
        _factory = new ApiWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Get_Space_ShoudlReturnOk()
    {
        var response = await _client.GetAsync("api/spaces");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PostSpace_ShouldReturnCreated()
    {

        var request = new CreateSpaceDtoRequest("Test Space", "Test Description");
        var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/spaces", json);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    public void Dispose()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ProjectHubDbContext>();
            db.Database.EnsureDeleted();
        }

        _client.Dispose();
        _factory.Dispose();
    }
}


