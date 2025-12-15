var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// usewhen takes is 2 arguments
app.UseWhen(
    context => context.Request.Query.ContainsKey("firstName"),
    // This is the branch that will be executed when the condition is true
    app =>
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from the middleware brach");
                await next();
            });        
        }
);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from middleware at main chain");
});

app.Run();
