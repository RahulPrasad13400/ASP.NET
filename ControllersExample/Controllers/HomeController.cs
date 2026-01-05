using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("xyz")]
        [Route("abc")]
        public string Method1()
        {
            return "Hello from abc";
        }

        [Route("home")]
        public ContentResult Home()
        {
            return new ContentResult()
            {
                Content = "Home Page",
                ContentType = "text/plain"
                //ContentType = "application/json"
            };
        }

        [Route("about")]
        public ContentResult About()
        {
            return Content("About page","text/plain");
        }

        [Route("contact-us/{mobile:int}")]
        public ContentResult Contact()
        {
            return Content("<h1>Hello World</h1>", "text/html");
        }
    }
}