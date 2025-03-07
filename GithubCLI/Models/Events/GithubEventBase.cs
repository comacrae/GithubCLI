using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GithubCLI.Models.Events.Responses;
using System.Resources;

namespace GithubCLI.Models.Events
{
    //The actor and Repo objects are just internal
    public class Actor
    {
        public long id { get; set; }
        public string login { get; set; }
        public string display_login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }

        public Actor(ActorResponse res)
        {
            this.id = res.id;
            this.login = res.login;
            this.display_login = res.display_login;
            this.gravatar_id = res.gravatar_id;
            this.url = res.url;
            this.avatar_url = res.avatar_url;
        }
    }
    public class Repo
    {
        public long id { get; set; }
        public string name { get; set; }
        public string url { get; set; }

        public Repo(RepoResponse res)
        {
            this.id = res.id;
            this.name = res.name;
            this.url = res.url;
        }
    }
    public abstract class GithubEventBase
    {
        public long id { get; set; } // needs to be converted to long
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public bool @public { get; set; }
        public DateTime created_at { get; set; } // needs to be converted to timestamp

    }
}
