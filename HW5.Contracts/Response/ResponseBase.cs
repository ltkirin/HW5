using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public abstract class ResponseBase
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public IDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }
}
