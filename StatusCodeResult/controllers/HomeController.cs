using Microsoft.AspNetCore.Mvc;

namespace StatusCodeResult.controllers
{
    public class HomeController : Controller
    {
        [Route("hello")]
        public IActionResult Xyz()
        {
            // Redirects the current request to another action method
            // Action Name  : "Abc"
            // Controller   : "HelloWorld"
            // Route Values : "hello-world"
            // return new RedirectToActionResult("Abc", "HelloWorld", "hello-wor/ld"); // Redirect to Action (302 Temporary)

            // RedirectToActionResult(string actionName, string controllerName, object routeValues, bool permanent)
            return new RedirectToActionResult("Abc", "HelloWorld", new {}, true); // 301 moved permanently 
        }
    }
}
