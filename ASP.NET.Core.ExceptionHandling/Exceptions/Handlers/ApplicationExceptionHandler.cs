using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Core.ExceptionHandling.Exceptions.Handlers;

public class ApplicationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ApplicationException e)
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