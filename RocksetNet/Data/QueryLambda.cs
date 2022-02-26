using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class QueryLambda
    {
        public string worksapce { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public SQL sql { get; set; }
    }
}
