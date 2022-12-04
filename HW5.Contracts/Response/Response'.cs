using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class Response
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public static Response Bad(string message)
        {
            return new Response()
            {
                Message = message,
                StatusCode = 400
            };
        }
        public static Response Failed(string message, int code = 500)
        {
            return new Response()
            {
                Message = message,
                StatusCode = code
            };
        }
        public static Response Forbidden(string message)
        {
            return new Response()
            {
                Message = message,
                StatusCode = 403
            };
        }
        public static Response NotFound(string message)
        {
            return new Response()
            {
                Message = message,
                StatusCode = 404
            };
        }
        public static Response Ok(string message = null)
        {
            return new Response()
            {
                Message = message,
                StatusCode = 200
            };
        }
        public static Response UnAuthorized(string message)
        {
            return new Response()
            {
                Message = message,
                StatusCode = 401
            };
        }


    }
}
