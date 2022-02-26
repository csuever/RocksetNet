using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RocksetNet.Data
{
    public class VirtualInstance
    {
        [JsonProperty("new_size")]
        public string NewSize { get; set; }

        [JsonProperty("new_type")]
        public string NewType { get; set; }

        [JsonProperty("monitoring_enabled")]
        public bool Monitoring { get; set; }
    }
    public class VirtualInstanceResponses
    {
        [JsonProperty("data")]
        public List<VirtualInstanceResponseData> Data { get; set; }
    }

    public class VirtualInstanceResponse 
    {

        [JsonProperty("data")]
        public VirtualInstanceResponseData Data { get; set; }
    }
    public class VirtualInstanceResponseData
    {

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("current_size")]
        public string? CurrentSize { get; set; }

        [JsonProperty("desired_size")]
        public string? DesiredSize { get; set; }

        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("estimated_switch_duration_minutes")]
        public int? EstimatedSwitchDuration { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
