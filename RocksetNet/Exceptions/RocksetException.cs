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
        public RocksetException() : base()
        {
        }

        public RocksetException(string? message, int? statusCode) : base(message)
        {
        }

        public RocksetException(string format, int statusCode, params object[] args) : base(string.Format(format, args))
        {
            this.StatusCode = statusCode;
        }

        public RocksetException(string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            this.StatusCode = statusCode;
        }

        public RocksetException(string format, int statusCode, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
            this.StatusCode = statusCode;
        }
    }
}
