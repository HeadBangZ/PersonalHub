using Newtonsoft.Json;
using ProjectHub.Api;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Tests.Integration.Mocks;
using System.Net;
using System.Text;
using Xunit.Abstractions;

namespace ProjectHub.Tests.Integration.Api;

public class SpaceControllerTests : IClassFixture<ApiWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public SpaceControllerTests(ApiWebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    [Fact]
    public async Task PostSpace_ShouldReturnCreated()
    {
        var request = new CreateSpaceDtoRequest("Test Space", "Test Description");

        var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/spaces", json);

        var responseContent = await response.Content.ReadAsStringAsync();
        var created = JsonConvert.DeserializeObject<SpaceDtoResponse>(responseContent);
        _output.WriteLine($"Response: {responseContent}");

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        Assert.NotNull(created);
        Assert.Equal(request.Name, created.Name);
    }
}
