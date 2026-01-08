using ControllersExample.models;
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

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Rahul",
                LastName = "Prasad",
                Age = 24
            };
            return new JsonResult(person);
        }

        // if the file is in wwwroot folder we can use VirtualFileResult
        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/crompton.pdf", "application/pdf");
            //In controllers instead of writing VirtualFileResult we can use File as a shortcut 
            return File("/crompton.pdf", "application/pdf");
        }

        // if the file is in other folder we can use PhysicalFileResult
        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult(@"C:\Users\rahul\OneDrive\Documents\GitHub\ASP.NET\ControllersExample\rahul\crompton.pdf", "application/pdf");
        }

        // FileContentResult is used when the file data is already available as a byte[] in memory
        // (e.g., files from database, generated files, or manually read from disk)
        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\rahul\OneDrive\Documents\GitHub\ASP.NET\ControllersExample\rahul\crompton.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            //In controllers instead of writing FileContentResult we can use File as a shortcut
            return File(bytes, "application/pdf");
        }

        // IActionResult - its the parent interface for all action result classes
        [Route("file-download4")]
        public IActionResult FileDownload4()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\rahul\OneDrive\Documents\GitHub\ASP.NET\ControllersExample\rahul\crompton.pdf");
            return File(bytes, "application/pdf");
        }
    }
}