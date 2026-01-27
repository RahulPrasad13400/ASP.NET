using Microsoft.AspNetCore.Mvc;

namespace StatusCodeResult.controllers
{
    public class HomeController : Controller
    {
        [Route("hello/{bookId}")]
        public IActionResult Xyz([FromRoute] int bookId)
        {
            // Redirects the current request to another action method
            // Action Name  : "Abc"
            // Controller   : "HelloWorld"
            // Route Values : "hello-world"
            // return new RedirectToActionResult("Abc", "HelloWorld", "hello-wor/ld"); // Redirect to Action (302 Temporary)


            // RedirectToActionResult(string actionName, string controllerName, object routeValues, bool permanent)
            //return new RedirectToActionResult("Abc", "HelloWorld", new {}, true); // 301 moved permanently 


            //return new RedirectToActionResult("Abc", "HelloWorld", new { id = bookId });
            // Abc - Action name 
            // HelloWorld - Controller name 
            // new { id = bookId } // Route value passed to Abc


            // Local Redirect Result
            //return new LocalRedirectResult($"~/hello-world/{bookId}", true); // 301 Moved Permanently
            // /hello-world/{bookId} this is a local url 

            return LocalRedirectPermanent($"/hello-world/{bookId}"); // 301 Permanent

        }
    }
}
