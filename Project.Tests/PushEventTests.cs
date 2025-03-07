using System.IO;
using System.Text.Json;
using GithubCLI.Models.Events;
using GithubCLI.Models.Events.Responses;

namespace Project.Tests
{
    public class PushEventTests
    {
        [Fact]
        public void PushEvent_InitFromResponse_Success()
        {
            var result = JsonSerializer.Deserialize<List<PushEventResponse>>(File.ReadAllText(@".\TestResponses\getUser.json"));
            PushEventResponse res = result[0];
            PushEvent e = new PushEvent(res);
            Assert.IsType<PushEvent>(e);
        }

    }
}
