using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapGet("rahul", async (context) => {
    await context.Response.WriteAsync("Hello Rahul!");
});


app.MapGet("files/{filename}.{extension}", async (context) =>
{
    var fileName = context.Request.RouteValues["filename"];
    var extension = context.Request.RouteValues["extension"];

    await context.Response.WriteAsync(fileName + "." + extension);


});

app.Map("products/details/{id:int}", async (HttpContext context) =>
{
    int id = Convert.ToInt32(context.Request.RouteValues["id"]);

    if (context.Request.RouteValues.ContainsKey("id"))
    {
        await context.Response.WriteAsync(id.ToString());
    } 
});

app.Map("daily-digest-report/{reportdate:datetime}", async (HttpContext context) =>
{
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
    await context.Response.WriteAsync($"{reportDate.ToShortDateString()}");
});


// If none of the routes match it will hit this end point
app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync("404 Not Found!");
});


app.Run();
