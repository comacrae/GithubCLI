using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GithubCLI.Models.Events.Responses
{
    //The actor and Repo objects are just internal
    public class ActorResponse
    {
        public long id { get; set; }
        public string login { get; set; }
        public string display_login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }
    public class RepoResponse
    {
        public long id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
    public abstract class GithubEventBaseResponse
    {
        public string id { get; set; } // needs to be converted to long
        public string type { get; set; }
        public ActorResponse actor { get; set; }
        public RepoResponse repo { get; set; }
        public bool @public { get; set; }
        public string created_at { get; set; } // needs to be converted to timestamp

    }
}
