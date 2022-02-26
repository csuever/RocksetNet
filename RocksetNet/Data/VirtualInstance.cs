using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class VirtualInstance
    {
        public string new_size { get; set; }
        public string new_type { get; set; }
        public bool monitoring_enabled { get; set; }
    }
    public class VirtualInstanceResponses
    {
        public List<VirtualInstanceResponseData> data { get; set; }
    }

    public class VirtualInstanceResponse { 
        public VirtualInstanceResponseData data { get; set; }
    }
    public class VirtualInstanceResponseData
    {
        public string? state { get; set; }
        public string? current_size { get; set; }
        public string? desired_size { get; set; }
        public string? last_updated { get; set; }
        public int? estimated_switch_duration_minutes { get; set; }
        public string id { get; set; }
    }
}
