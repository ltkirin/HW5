using HW5.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Business.Util
{
    public static class ResponseExtensions
    {
        public static void SetTotal<TResponse>(this TResponse response, int total) where TResponse : ResponseBase
        {
            response.Metadata.Add("Total", total.ToString());
        }
        public static TResponse SetTotalReturn<TResponse>(this TResponse response, int total) where TResponse : ResponseBase
        {
            response.Metadata.Add("Total", total.ToString());
            return response;
        }
    }
}
