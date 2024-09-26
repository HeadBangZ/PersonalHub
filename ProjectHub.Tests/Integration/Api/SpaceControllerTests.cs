using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Infrastructure.Data.Contexts;
using ProjectHub.Tests.Integration.Mocks;
using System.Net;
using System.Text;

namespace ProjectHub.Tests.Integration.Api;

public class SpaceControllerTests : IAsyncLifetime
{
    private ApiWebApplicationFactory _factory;
    private HttpClient _client;

    [Fact]
    public async Task GetSpaces_ShoudlReturnOk()
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

    [Fact]
    public async Task PostSpace_ShouldReturnBadRequest()
    {

        var request = new CreateSpaceDtoRequest("", "Test Description");
        var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/spaces", json);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetSpaceById_ShouldReturnNotFound()
    {
        var id = Guid.NewGuid();
        var response = await _client.GetAsync($"/api/spaces/{id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetSpaceById_ShouldReturnOk()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ProjectHubDbContext>();

            var spaces = SeedTestData.CreateMultipleSpaceData(context, 1);
            var id = spaces.First().Id;

            var response = await _client.GetAsync($"/api/spaces/{id.Id}");

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

    [Fact]
    public async Task DeleteSpaceById_ShouldReturnNotFound()
    {
        var id = Guid.NewGuid();
        var response = await _client.DeleteAsync($"/api/spaces/{id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    public async Task InitializeAsync()
    {
        _factory = new ApiWebApplicationFactory();
        _client = _factory.CreateClient();

        await Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ProjectHubDbContext>();
            db.Database.EnsureDeleted();
        }

        _client.Dispose();
        _factory.Dispose();

        await Task.CompletedTask;
    }
}


