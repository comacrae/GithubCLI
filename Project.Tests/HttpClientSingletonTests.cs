namespace Project.Tests;
using GithubCLI.Models;

public class HttpClientSingletonTests
{
    [Fact]
    public async Task HttpClientSingleton_GetAsyncBaseURI_HasValidStatusCode()
    {
        var response = await HttpClientSingleton.Instance.GetAsync("");
        Assert.True(response.IsSuccessStatusCode);
    }
    [Theory]
    public async Task
}