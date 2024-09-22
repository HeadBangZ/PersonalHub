using Newtonsoft.Json;
using ProjectHub.Api;
using ProjectHub.Application.DTOs.SpaceDtos;
using ProjectHub.Tests.Integration.Suite;
using ProjectHub.Tests.Integration.Suite.Mocks;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectHub.Tests.Integration.Api;

public class SpaceControllerTests : ApiIntegrationTestFixture
{
    public SpaceControllerTests()
    {
    }

    [Fact]
    public async Task PostSpace_ShouldReturnCreated()
    {
        var request = new CreateSpaceDtoRequest("Test Space", "Test Description");
        var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync("/api/spaces", json);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        //_client.DefaultRequestHeaders.Accept.Clear();
        //_client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //var response = await _client.PostAsync();

        //Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        //var responseContent = await response.Content.ReadAsStringAsync();
        //var created = JsonConvert.DeserializeObject<SpaceDtoResponse>(responseContent);

        //Assert.NotNull(created);
        //Assert.Equal(request.Name, created.Name);
    }
}

