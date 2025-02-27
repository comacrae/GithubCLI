namespace Project.Tests;
using GithubCLI.Services;
using GithubCLI.Models;
using Xunit.Abstractions;

public class HttpClientSingletonTests: IClassFixture<EnvFixture>
{
    private readonly ITestOutputHelper _output;
    public HttpClientSingletonTests(ITestOutputHelper output)
    {
        _output = output;
    }
    [Fact]
    public void Token_IsLoaded()
    {
        DotNetEnv.Env.Load("C:\\Users\\comac\\source\\repos\\GithubCLI\\GithubCLI\\.env");
        string? token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        Assert.False(String.IsNullOrEmpty(token));
    }
    [Fact]
    public async Task HttpClientSingleton_GetAsyncBaseURI_HasValidStatusCode()
    {
        var response = await HttpClientSingleton.Instance.GetAsync("");
        Assert.True(response.IsSuccessStatusCode);
    }
    [Fact]
    public async Task HttpClientSingleton_GetValidUser_HasValidStatusCode()
    {
        string username = "comacrae";
        User u = await HttpClientSingleton.GetUserResponse(username);
        Assert.NotNull(u);
        Assert.True(u.Response.IsSuccessStatusCode);
    }
    [Fact]
    public async Task HttpClientSingleton_GetInvalidUser_ThrowsError()
    {
        string username = "1234;eaqfoiha2314";
        await Assert.ThrowsAsync<HttpRequestException>( async () => await HttpClientSingleton.GetUserResponse(username));

    }
    [Fact]
    public async Task HttpClientSIngleton_WriteResponseToFile_CreatesFile()
    {
        string username = "comacrae";
        User u = await HttpClientSingleton.GetUserResponse(username);
        Assert.NotNull(u);
        Assert.NotNull(u.Body);
        string json = u.Body; //JSON parsed contents
        u.WriteToFile("output.json"); // saves to file at path
        u.LoadFromFile("output.json"); // reads from file at path
        Assert.Equal(json, u.Body);

    }
}