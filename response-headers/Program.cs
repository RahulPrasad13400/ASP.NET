using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    //context.Response.Headers["MyName"] = "Rahul";

    // ITS BEEN GIVEN TO INFORM THE BROWSER, ABOUT THE CONTENT TYPE AS HTML
    //context.Response.Headers["Content-Type"] = "text/html";

    //await context.Response.WriteAsync("Hello");
    //await context.Response.WriteAsync("<h2>Hello World</h2>");


    // Cache-Control
    // INDICATES THE NUMBER OF SECONDS THAT THE RESPONSE CAN BE CACHED AT THE BROWSER


    // GETS THE REQUESTED PATH 
    //string path = context.Request.Path;
    //Console.WriteLine(path);


    // GETS THE REQUESTED METHOD 
    //string method = context.Request.Method;
    //Console.WriteLine(method);


    // HTTP REQUEST WITH QUERY STRING
    // /dashboard?id=3
    //if (context.Request.Method == "GET")
    //{
    //    var query = "";
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        query = context.Request.Query["id"];
    //    }
    //    await context.Response.WriteAsync($"<h1>{query}</h1>");
    //}


    //BODY
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    // if it is in this format - name=rahul&age=30
    // we need to extract the values
    Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
    // or name=rahul&age=30&age=20 -> in this case it will be like this age = 20,30 in the dictionary
    // we give here stringValues because it can represent multiple values if it was string it represent only one value

    if (queryDict.ContainsKey("name"))
    {
        await context.Response.WriteAsync(queryDict["name"]!);
    }
   
     
});
app.Run();