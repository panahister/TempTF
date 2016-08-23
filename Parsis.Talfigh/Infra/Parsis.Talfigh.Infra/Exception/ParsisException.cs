using System.Net;

using System.Configuration;
using System.Linq;

using System.Collections.Generic;

namespace Parsis.Talfigh.Infra.Exception
{
    public class ParsisException : System.Exception
    {

        static ParsisException()
        {

        }

        public ParsisException()
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
        }

        public ParsisException(string message)
        {
            this.ExceptionType = ExceptionType.BadRequest;
            this.Message = message;
            this.StatusCode = HttpStatusCode.BadRequest;

        }

        public ParsisException(ExceptionType type, System.Exception originallException = null)
        {
            this.ExceptionType = type;
            this.Message = "";
            this.StatusCode = (HttpStatusCode)type;
            this.OriginallException = originallException;

        }

        public ParsisException(string message, ExceptionType type, System.Exception originallException = null)
        {
            this.ExceptionType = type;
            this.Message = message;
            this.StatusCode = (HttpStatusCode)type;
            this.ExceptionType = type;
            this.OriginallException = originallException;
        }

        public string Message { get; set; }

        public ExceptionType ExceptionType { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public System.Exception OriginallException { get; set; }

        

    }
}