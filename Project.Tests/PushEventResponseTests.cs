using GithubCLI.Models;
using GithubCLI.Models.Events.Responses;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
namespace Project.Tests
{
    public class PushEventResponseTests

    {
        [Fact]
        public void PushEventResponse_Deserialize_Success()
        {
            var result = JsonSerializer.Deserialize<List<PushEventResponse>>(File.ReadAllText(@".\TestResponses\getUser.json"));
            Assert.All<PushEventResponse>(result, pushEvent => Assert.IsType<PushEventResponse>(pushEvent));
        }

    }
}
