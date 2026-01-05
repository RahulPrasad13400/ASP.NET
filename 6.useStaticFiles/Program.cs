// wwwroot
// create a folder named wwwroot put the files or img in it 
// it can be access directly by typing the url http://localhost:5000/filename.pdf
// also need to add app.UseStaticFiles();


// if we are using other foler name instead of wwwroot we have to specify it in the code like below



//var builder = WebApplication.CreateBuilder(args);

var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions()
    {
        WebRootPath = "myroot"
    });
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
