using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MediatRCore.Infrastructure.Exceptions
{
    public class RestException:Exception
    {
        public RestException(HttpStatusCode code, object message = null)
        {
            Code = code;
            Message = message;
        }

        public HttpStatusCode Code { get; }

        public new object Message { get; }
    }
}
