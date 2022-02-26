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
        [JsonProperty("data")]
        public AliasResponseData Data { get; set; }
    }
    public class AliasResponses
    {
        [JsonProperty("data")]
        public List<AliasResponseData> Data { get; set; }
    }

    public class AliasResponseData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("creator_email")]
        public string CreatedBy { get; set; }

        [JsonProperty("collections")]
        public List<string> Collections { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("modified_at")]
        public DateTime LastModified { get; set; }
    }
}
