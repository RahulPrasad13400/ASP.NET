using Microsoft.AspNetCore.Mvc;

namespace Razor_Views.controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            //return new ViewResult() { ViewName = "abc"};
            return View();
        }
    }
}
