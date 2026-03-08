using _12.ModelValidations.CustomModelBinders;
using _12.ModelValidations.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _12.ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost("register")]
        //public IActionResult Index([Bind("PersonName", "Email")]_12.ModelValidations.Models.Person person)
        //public IActionResult Index([Bind(nameof(Person.Name), nameof(Person.Email))] _12.ModelValidations.Models.Person person)


        // Custom Model Binder
        //public IActionResult Index([ModelBinder(BinderType = typeof(PersonModelBinder))]_12.ModelValidations.Models.Person person)
        public IActionResult Index([ModelBinder(BinderType = typeof(PersonModelBinder))] _12.ModelValidations.Models.Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
                //List<string> errors = new List<string>();
                //foreach(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry value in ModelState.Values)
                //{
                //    foreach(Microsoft.AspNetCore.Mvc.ModelBinding.ModelError error in value.Errors)
                //    {
                //        errors.Add(error.ErrorMessage);
                //    }
                //}
                //string.Join("\n", errors);
                //return BadRequest(errors);

                List<string> errorsList = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                string errors = string.Join("\n", errorsList);
                return BadRequest(errors);
            }

            return Ok();
        }
    }
}
