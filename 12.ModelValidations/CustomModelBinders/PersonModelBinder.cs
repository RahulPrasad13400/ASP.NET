using _12.ModelValidations.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _12.ModelValidations.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();

            // Getting the First Name and Last Name
            if(bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.Name = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
            }

            if(bindingContext.ValueProvider.GetValue("LastName").Length > 0)
            {
                person.Name += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }

            // Also need to bind all the other values otherwise it will all become null
            // Need to bind values like email, password, and other values ...

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
