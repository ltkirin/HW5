using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class Response<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public static Response<T> Bad(string message)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = 400
            };
        }
        public static Response<T> Failed(string message, int code = 500)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = code
            };
        }
        public static Response<T> Forbidden(string message)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = 403
            };
        }
        public static Response<T> NotFound(string message)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = 404
            };
        }
        public static Response<T> Ok(T data, string message = null)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = 200,
                Data = data
            };
        }
        public static Response<T> UnAuthorized(string message)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = 401
            };
        }


    }
}

