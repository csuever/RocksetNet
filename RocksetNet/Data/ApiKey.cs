using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class ApiKey
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }
    public class ApiKeyResponse
    {
        [JsonProperty("data")]
        public ApiKeyResponseData Data { get; set; }
    }
    public class ApiKeyResponses
    {
        [JsonProperty("data")]
        public List<ApiKeyResponseData> Data { get; set; }
    }
    public class ApiKeyResponseData
    {
        [JsonProperty("created_at")]
        public string DateCreated { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("last_access_time")]
        public DateTime LastAccessed { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
