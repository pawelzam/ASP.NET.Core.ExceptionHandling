using System.Net;

namespace ASP.NET.Core.ExceptionHandling.Exceptions;

public class ItemNotFoundException() : BaseException(HttpStatusCode.NotFound)
{
    
}