using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class View
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
    }

    public class ViewResponse
    {
        [JsonProperty("data")]
        public ViewResponseData Data { get; set; }
    }

    public class ViewResponses
    {
        [JsonProperty("data")]
        public List<ViewResponseData> Data { get; set; }
    }

    public class ViewResponseData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("creator_email")]
        public string Creator { get; set; }

        [JsonProperty("owner_email")]
        public string Owner { get; set; }

        [JsonProperty("query_sql")]
        public string QuerySql { get; set; }

        [JsonProperty("entities")]
        public List<string> Entities { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("modified_at")]
        public DateTime LastModified { get; set; }
    }
}
