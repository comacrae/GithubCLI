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
    [Fact]
    public async Task HttpClientSingleton_GetValidUserEvents_HasValidStatusCode()
    {

        string username = "comacrae";
        var response = await HttpClientSingleton.Instance.GetAsync($"{}");
        Assert.True(response.IsSuccessStatusCode);

    }
}