using System.ComponentModel.DataAnnotations;

// CREATING CUSTOM VALIDATORS 

namespace _12.ModelValidations.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0]";

        // parameterless constructor 
        public MinimumYearValidatorAttribute()
        { 
        }

        // parameterized constructor
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = (DateTime)value;
                //if(date.Year <= 2000)
                if (date.Year <= MinimumYear)
                {
                    //return new ValidationResult("Minimum year allowed is 2000");
                    // If the error message is been given the model class we can access it directly by using ErrorMessage
                    //return new ValidationResult(ErrorMessage);
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            // RETURN NULL MEANS NO VALIDATION

            return null;
        }
    }
}
