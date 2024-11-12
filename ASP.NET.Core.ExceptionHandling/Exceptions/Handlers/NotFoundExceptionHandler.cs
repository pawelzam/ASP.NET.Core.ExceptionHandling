using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Core.ExceptionHandling.Exceptions.Handlers;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ItemNotFoundException e)
        {
            return false;
        }

        var problemDetails = new ProblemDetails
        {
            Instance = httpContext.Request.Path,
            Title = exception.Message,
            Status = (int)e.StatusCode
        };

        httpContext.Response.StatusCode = (int)e.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
        return true;
    }
}