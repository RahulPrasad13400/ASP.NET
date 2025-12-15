using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewaresExample
{
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("firstName") &&
                httpContext.Request.Query.ContainsKey("lastName"))
            {
                string fullName = httpContext.Request.Query["firstName"] + " " +
                    httpContext.Request.Query["lastName"];
                await httpContext.Response.WriteAsync(fullName);
            }
            await _next(httpContext);
        }
    }

    public static class HelloCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
