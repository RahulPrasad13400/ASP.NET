using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _12.ModelValidations.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) {
                DateTime toDate = Convert.ToDateTime(value);

                // LEARN ABOUT THE REFLECTION CONCEPT IN THE C#
                // REFLECTION
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    }    
                    
                    return ValidationResult.Success;
                    
                }

                return ValidationResult.Success;
            }

            return ValidationResult.Success;
           
        }
    }
}
