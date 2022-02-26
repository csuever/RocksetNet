using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class WorkspaceResponse
    {
        public Workspace data { get; set; }
    }
    public class WorkspaceResponses
    {
        public List<Workspace> data { get; set; }
    }
    public class Workspace
    {
        public string created_at { get; set; }
        public string created_by { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int collection_count { get; set; }
    }
}
