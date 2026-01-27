// STATUS CODE RESULTS 
// 1. return new StatusCodeResult(statusCode);
// 2. return new UnauthorizedResult();
// 3. return new BadRequestResult();
// 4. return new NotFoundResult();

// REDIRECT RESULTS
// from /bookstore (old url) to /store/books (new url)

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run();
