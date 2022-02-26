using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class Integration
    {
    }

    public class IntegrationResponse
    {
        [JsonProperty("data")]
        public Source Data { get; set; }
    }
    public class IntegrationResponses
    {
        [JsonProperty("data")]
        public List<Source> Data { get; set; }
    }
}
