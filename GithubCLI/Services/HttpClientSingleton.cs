using System;
using System.Net.Http;
using DotNetEnv;
using GithubCLI.Models;
namespace GithubCLI.Services;


public static class HttpClientSingleton
{
    public static readonly HttpClient Instance = new HttpClient
    {
        BaseAddress = new Uri("https://api.github.com"),
        Timeout = TimeSpan.FromSeconds(30)
    };
    static HttpClientSingleton()
    {
        DotNetEnv.Env.Load("C:\\Users\\comac\\source\\repos\\GithubCLI\\GithubCLI\\.env"); // need to come up with a better method for this in future
        string? token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        if(String.IsNullOrEmpty(token))
        {
                throw new Exception("GITHUB_TOKEN does not exist in environment variables");
        }
        Instance.DefaultRequestHeaders.Add("User-Agent", "comacraeGithubCLIApp/1.0");
        Instance.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
        Instance.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
        Instance.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

    }

    public static async Task<User> GetUserResponse(string username)
    {
        string uri = $"/users/{username}/events";
        HttpResponseMessage response = await Instance.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            return await User.BuildUser(username, response);
        }
        else
        {
            throw new HttpRequestException($"Unable to get user {username}; HTTP Status Code{response.StatusCode}");
        }
    }

}
