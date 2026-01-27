using Microsoft.AspNetCore.Mvc;

namespace StatusCodeResult.controllers
{
    public class HelloWorld : Controller
    {
        [Route("hello-world")]
        public IActionResult Abc()
        {
            return Content("hello-world");
        }
    }
}
