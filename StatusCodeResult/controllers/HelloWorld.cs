using Microsoft.AspNetCore.Mvc;

namespace StatusCodeResult.controllers
{
    public class HelloWorld : Controller
    {
        // Getting the value of id from Home Controller where we had written the redirection 
        [Route("hello-world/{id}")]
        public IActionResult Abc()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"hello-world : {id}");
        }
    }
}
