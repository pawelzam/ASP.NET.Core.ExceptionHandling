using System.Net;

namespace ASP.NET.Core.ExceptionHandling.Exceptions;

public class ApplicationException(): BaseException(HttpStatusCode.BadRequest)
{
}
