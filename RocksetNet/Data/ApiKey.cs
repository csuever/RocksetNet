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
        public ApiKeyResponseData data { get; set; }
    }
    public class ApiKeyResponses
    {
        public List<ApiKeyResponseData> data { get; set; }
    }
    public class ApiKeyResponseData
    {
        public string created_at { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string last_acccess_time { get; set; }
        public string created_by { get; set; }
        public string state { get; set; }
    }
}
