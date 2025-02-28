using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubCLI.Models.Events;

namespace Project.Tests
{
    public class GithubEventFixture: IDisposable
    {
        public List<GithubEventBase> events {  get; private set; }
        public GithubEventFixture() {
            events = new List<GithubEvent>();
        }
    }
    public class GithubEventTests: IClassFixture<GithubEventFixture>
    {
        GithubEventFixture fixture;
        public GithubEventTests(GithubEventFixture fixture) { 
            this.fixture = fixture;
        }

        
    }
}
