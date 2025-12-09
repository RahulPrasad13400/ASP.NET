var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// HELLO WORLD WILL BE DISPLAYED ON THE SCREEN 
app.MapGet("/", () => "Hello World");

app.UseHttpsRedirection();

app.Run();


