var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>();  // we can register controllers like this 
builder.Services.AddControllers(); // adds all the controller classes as services

var app = builder.Build();

app.MapControllers();

app.Run();
