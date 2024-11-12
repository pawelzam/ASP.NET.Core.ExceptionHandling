using ASP.NET.Core.ExceptionHandling.Exceptions.Handlers;

namespace ASP.NET.Core.ExceptionHandling.Extensions;

public static class ExceptionExtensions
{
    public static void AddExceptionHandlers(this IServiceCollection services)
    {
       services.AddExceptionHandler<NotFoundExceptionHandler>();
       services.AddExceptionHandler<ApplicationExceptionHandler>();
    }
}
