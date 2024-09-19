using Newtonsoft.Json;
using ProjectHub.Api;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Tests.Integration.Mocks;
using System.Net;
using System.Text;

namespace ProjectHub.Tests.Integration.Api;

public class SpaceControllerTests : IClassFixture<ApiWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public SpaceControllerTests(ApiWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostSpace_ShouldReturnCreated()
    {
        var request = new CreateSpaceDtoRequest("Test Space", "Test Description");

        var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/spaces", json);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var reponseContent = await response.Content.ReadAsStringAsync();
        var created = JsonConvert.DeserializeObject<SpaceDtoResponse>(reponseContent);

        Assert.NotNull(created);
        Assert.Equal(request.Name, created.Name);
    }
}
