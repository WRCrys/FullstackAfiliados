using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FullstackAfiliados.Api.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ArgumentException ex)
        {
            await HandleArgumentException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGenericException(context, ex);
        }
    }

    private static Task HandleArgumentException(HttpContext context, Exception exception)
    {
        var status400 = HttpStatusCode.BadRequest.GetHashCode();
        
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = status400;

        var problemDetails = new ValidationProblemDetails
        {
            Type = $"https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/{status400}",
            Title = exception.GetBaseException().Message,
            Status = status400,
            Detail = string.Empty,
            Instance = exception.Source
        };

        return context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
    }
    
    private static Task HandleGenericException(HttpContext context, Exception exception)
    {
        var status500 = HttpStatusCode.InternalServerError.GetHashCode();
        
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = status500;

        var problemDetails = new ValidationProblemDetails
        {
            Type = $"https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/{status500}",
            Title = exception.GetBaseException().Message,
            Status = status500,
            Detail = JsonConvert.SerializeObject(exception.GetBaseException()),
            Instance = exception.Source
        };

        return context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
    }
}