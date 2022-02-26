using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class View
    {
        public string name { get; set; }
        public string description { get; set; }
        public string query { get; set; }
    }

    public class ViewResponse
    {
        public ViewResponseData data { get; set; }
    }

    public class ViewResponses
    {
        public List<ViewResponseData> data { get; set; }
    }

    public class ViewResponseData
    {
        public string name { get; set; }
        public string description { get; set; }
        public string workspace { get; set; }
        public string creator_email { get; set; }
        public string owner_email { get; set; }
        public string query_sql { get; set; }
        public List<string> entities { get; set; }
        public string state { get; set; }
        public string created_at { get; set; }
        public string modified_at { get; set; }
    }
}
