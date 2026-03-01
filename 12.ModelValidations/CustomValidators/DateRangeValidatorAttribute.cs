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
        public override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) {
                DateTime toDate = Convert.ToDateTime(value);

                // LEARN ABOUT THE REFLECTION CONCEPT IN THE C#
                // REFLECTION
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                if (fromDate > toDate)
                {
                    return new ValidationResult(ErrorMessage, new[] { OtherPropertyName, validationContext.MemberName });
                }
            }
        }
    }
}
