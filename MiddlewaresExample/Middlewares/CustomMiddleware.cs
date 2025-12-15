
namespace MiddlewaresExample.Middlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nHello from Custom Middleware\n");
            await next(context);
        }
    }


    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder DoSomething(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
