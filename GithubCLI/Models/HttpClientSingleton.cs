using System;
using System.Net.Http;
namespace GithubCLI.Models;


public static class HttpClientSingleton
{
    public static readonly HttpClient Instance = new HttpClient
    {
        BaseAddress = new Uri("https://api.github.com"),
        Timeout = TimeSpan.FromSeconds(30)
    };
    static HttpClientSingleton()
    {
        Instance.DefaultRequestHeaders.Add("User-Agent", "comacraeGithubCLIApp/1.0");
        Instance.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
        Instance.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
    }
}
