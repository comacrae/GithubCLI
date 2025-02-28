using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GithubCLI.Models.Events
{
    //The actor and Repo objects are just internal
    public class Actor
    {
        public int id { get; set; }
        public string login { get; set; }
        public string display_login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }
    public class Repo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
    public abstract class GithubEventBase
    {
        public int id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public bool @public { get; set; }
        public string created_at { get; set; }

    }
}
