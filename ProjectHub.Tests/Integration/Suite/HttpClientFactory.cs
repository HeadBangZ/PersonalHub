using ProjectHub.Tests.Integration.Suite.Mocks;

namespace ProjectHub.Tests.Integration.Suite;

public static class HttpClientFactory
{
    public static HttpClient Create(ApiWebApplicationFactory factory)
    {
        var httpClient = factory.CreateClient();
        httpClient.BaseAddress = new Uri("https://localhost/");

        return httpClient;
    }
}
