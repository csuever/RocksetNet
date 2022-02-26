using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class WorkspaceResponse
    {
        [JsonProperty("data")]
        public Workspace Data { get; set; }
    }
    public class WorkspaceResponses
    {
        [JsonProperty("data")]
        public List<Workspace> Data { get; set; }
    }
    public class Workspace
    {

        [JsonProperty("created_at")]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("collection_count")]
        public int CollectionCount { get; set; }
    }
}
