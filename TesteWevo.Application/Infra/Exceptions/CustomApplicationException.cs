using System;
using System.Net;

namespace TesteWevo.Application.Infra.Exceptions
{

    public class CustomApplicationException : Exception
    {

        public string Code { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public CustomApplicationException(string message, string code, HttpStatusCode statusCode = HttpStatusCode.LengthRequired) 
            : base(message)
        {

            Code = code;
            StatusCode = statusCode;

        }

    }

}
