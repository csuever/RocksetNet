using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace RocksetNet.Exceptions
{
    public class RocksetException : Exception
    {
        public int? StatusCode { get; set; }
        public RocksetException() : base() { }
        public RocksetException(string message) : base(message) { }
        public RocksetException(string format, params object[] args) : base(string.Format(format, args)) { }
        public RocksetException(string message,  Exception innerException) : base(message, innerException) {}
        public RocksetException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
        public RocksetException(string message, int? statusCode)
                : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
