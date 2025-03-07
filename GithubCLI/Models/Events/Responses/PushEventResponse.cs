﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GithubCLI.Models.Events.Responses
{
    public class PushPayloadResponse
    {
        public long repository_id { get; set; }
        public long push_id { get; set; }
        public int size { get; set; }
        public int distinct_size { get; set; }
        public string @ref { get; set; }
        public string head { get; set; }
        public string before { get; set; }
    }
    public class PushEventResponse : GithubEventBaseResponse
    {
        public PushPayloadResponse payload { get; set; }
    }
}
