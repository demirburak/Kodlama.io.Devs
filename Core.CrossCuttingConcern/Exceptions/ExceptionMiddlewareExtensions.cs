using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseMiddleware<ExceptionMiddleware>();
    }
}