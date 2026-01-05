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

        [Route("homw")]
        public string Home()
        {
            return "Home Page";
        }

        [Route("about")]
        public string About()
        {
            return "About Page";
        }

        [Route("contact-us/{mobile:int}")]
        public string Contact()
        {
            return "Contact Page";
        }
    }
}