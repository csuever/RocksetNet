using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class Integration
    {
    }

    public class IntegrationResponse
    {
        public Source data { get; set; }
    }
    public class IntegrationResponses
    {
        public List<Source> data { get; set; }
    }
}
