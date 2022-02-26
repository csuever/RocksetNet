using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class NotificationPreference
    {
        public string notificationType { get; set; }
    }

    public class NotificationPreferenceResponse
    {
        public List<NotificationPreference> data { get; set; }
    }
}
