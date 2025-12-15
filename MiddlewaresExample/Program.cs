using MiddlewaresExample;
using MiddlewaresExample.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Registering the custom middleware 
builder.Services.AddTransient<CustomMiddleware>();


var app = builder.Build();

app.Use(async (HttpContext context,RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from first Middleware");
    await next(context);
});


// Custom Middleware
app.UseMiddleware<CustomMiddleware>();

app.UseHelloCustomMiddleware();


app.DoSomething();

// app.Run is used to create an terminating or
// short circuiting middleware that dosen't forward the request 
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello from second Middleware");
});

app.Run();



// DELEGATE

//using System;

//public class HelloWorld
//{
//    delegate void MyDelegate(int age);

//    static void Adult(int age)
//    {
//        Console.WriteLine("You are an adult of age " + age);
//    }

//    static void Child(int age)
//    {
//        Console.WriteLine("You are a child of age " + age);
//    }

//    public static void Main(string[] args)
//    {
//        int age = 25;
//        MyDelegate del;
//        if (age > 18)
//        {
//            del = Adult;
//        }
//        else
//        {
//            del = Child;
//        }
//        del(age);
//    }
//}