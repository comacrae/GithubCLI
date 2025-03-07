using GithubCLI.Models.Events.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GithubCLI.Models.Events
{
    public class PushPayload
    {
        public long repository_id {  get; set; }
        public long push_id { get; set; }
        public int size { get; set; }
        public int distinct_size { get; set; }
        public string @ref {get; set;}
        public string head { get; set; }
        public string before { get; set; }

        public PushPayload(PushPayloadResponse res)
        {
            this.repository_id = res.repository_id;
            this.push_id = res.push_id;
            this.size = res.size;
            this.distinct_size = res.distinct_size;
            this.@ref = res.@ref;
            this.head = res.head;
            this.before = res.before;
        }
    }
    public class PushEvent : GithubEventBase
    {
        public PushPayload payload { get; set; }

        public PushEvent(PushEventResponse res) {
            this.payload = new PushPayload(res.payload); // nothing to change;

            //converting base class attributes

            this.id = (long) Convert.ToDouble(res.id);
            this.type = res.type;
            this.actor = new Actor(res.actor);
            this.repo = new Repo(res.repo);
            this.@public = res.@public;
            this.created_at = Convert.ToDateTime(res.created_at);
        }
    }
}
