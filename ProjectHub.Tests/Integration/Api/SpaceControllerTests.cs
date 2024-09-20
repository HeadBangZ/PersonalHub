using Newtonsoft.Json;
using ProjectHub.Api;
using ProjectHub.Application.DTOs.SpaceDtos;
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

        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.PostAsync("/api/spaces", json);

        var responseContent = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var created = JsonConvert.DeserializeObject<SpaceDtoResponse>(responseContent);

        Assert.NotNull(created);
        Assert.Equal(request.Name, created.Name);
    }
}

