// wwwroot
// create a folder named wwwroot put the files or img in it 
// it can be access directly by typing the url http://localhost:5000/filename.pdf
// also need to add app.UseStaticFiles();


// if we are using other foler name instead of wwwroot we have to specify it in the code like below



//var builder = WebApplication.CreateBuilder(args);

// if it is for only one folder we can do it like this 
//var builder = WebApplication.CreateBuilder(
//    new WebApplicationOptions()
//    {
//        WebRootPath = "myroot"
//    });
//var app = builder.Build();

//app.UseStaticFiles();


// If there exist more than one folder with the assets we need to do it like this 
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions()
    {
        WebRootPath = "myroot"
    });
var app = builder.Build();

app.UseStaticFiles();   // works with the web root path (myroot)
app.UseStaticFiles(new StaticFileOptions()  // for additional folder we have to do it like this
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")    
    )
});   // works with mywebroot 

app.MapGet("/", () => "Hello World!");

app.Run();
