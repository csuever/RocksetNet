using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class NotificationPreference
    {

        [JsonProperty("notificationType")]
        public string NotificationType { get; set; }
    }

    public class NotificationPreferenceResponse
    {
        [JsonProperty("data")]
        public List<NotificationPreference> Data { get; set; }
    }
}
