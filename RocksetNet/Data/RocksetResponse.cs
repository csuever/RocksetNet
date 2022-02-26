using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class RocksetResponse
    {
        public int? statusCode { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}
