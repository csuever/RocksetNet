using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class Alias
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("collections")]
        public List<string> Collections { get; set; }
    }

    public class AliasResponse
    {
        public AliasResponseData data { get; set; }
    }
    public class AliasResponses
    {
        public List<AliasResponseData> data { get; set; }
    }

    public class AliasResponseData
    {
        public string name { get; set; }
        public string description { get; set; }
        public string workspace { get; set; }
        public string creator_email { get; set; }
        public List<string> collections { get; set; }
        public string state { get; set; }
        public string created_at { get; set; }
        public string modified_at { get; set; }
    }
}
