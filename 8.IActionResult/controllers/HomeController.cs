using Microsoft.AspNetCore.Mvc;

namespace IActionResultcontrollers
{
    public class HomeController : Controller
    {
        [Route("abc")]
        public IActionResult Index()
        {
            //return Content("Hello World");

            //Book Id can't be empty 
            if (string.IsNullOrWhiteSpace(Convert.ToString(Request.Query["bookid"])))
            {
                return Content("Book Id can't be null or empty");
            }

            //Book Id should be between 1 and 1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if(bookId <= 0)
            {
                return Content("Book id can't be less than or equal to zero");
            }
            if(bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id can't be greater than 1000");
            }

            //IsLoggedIn should be true 
            if (Convert.ToBoolean(Request.Query["isLoggedIn"]) == false)
            {
                Response.StatusCode = 401;
                return Content("User must be authenticated");
            }

            return File("/crompton.pdf", "application/pdf");
        }
    }
}
