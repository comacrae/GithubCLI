using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.IO;

namespace GithubCLI.Models;
public class User
{
    public string Username { get; set; }
    public HttpResponseMessage Response { get; set; }
    
    public string Body { get; set; }

    public static async Task<User> BuildUser(string username, HttpResponseMessage response)
    {
        string body = await response.Content.ReadAsStringAsync();
        return new User(username, response, body);

    }
    public User(string username, HttpResponseMessage response, string body)
    {
        Username = username;
        Response = response;
        Body = body; 
    }

    public void WriteToFile(string filename)
    {
        //for testing json output
        string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string fullPath = Path.Combine(dirPath, filename);
        File.WriteAllText(fullPath, Body);
    }

    public void LoadFromFile(string filename)
    {
        string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string fullPath = Path.Combine(dirPath, filename);
        this.Body = File.ReadAllText(fullPath);
    }

}