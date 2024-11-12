using System.Net;

namespace ASP.NET.Core.ExceptionHandling.Exceptions;

public class BaseException(HttpStatusCode statusCode) : Exception
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
