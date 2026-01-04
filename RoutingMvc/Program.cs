using RoutingMvc.CustomConstraint;

var builder = WebApplication.CreateBuilder(args);

// registering the custom constraints
builder.Services.AddRouting(options =>
    // "months" is the constraint name used in routes
    // MonthCustomConstraint is the class that performs the validation
{   // we have to give the constraint and the type of the custom constraint class 
    options.ConstraintMap.Add("months", typeof(MonthCustomConstraint));
});

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

// employee/profile/john
app.Map("employee/profile/{name:minlength(3):maxlength(10)}", async (HttpContext context) =>
{
    string? employeeName = Convert.ToString(context.Request.RouteValues["name"]);
    await context.Response.WriteAsync("Emplyoee name is : " + employeeName);
});


// sales-report/2030/apr
app.Map("sales-report/{year:int}/{month:months}", async (HttpContext context) =>
{
    int? year = Convert.ToInt32(context.Request.RouteValues["year"]);
    string? month = Convert.ToString(context.Request.RouteValues["month"]);

    await context.Response.WriteAsync(year + " " + month);
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
