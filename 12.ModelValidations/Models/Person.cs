using _12.ModelValidations.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _12.ModelValidations.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} cannot be empty or null")]
        // Index number 0 represents the Person Name 
        // If name is defined in the display it takes up that name
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string? Name { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; } 
        [ValidateNever]
        public string? Phone { get; set; }
        public string? Password { get; set; }
        // It compares the value with the password
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        // Index number 0 represents the Price
        // Index number 1 represents the minimum in the range
        // Index number 2 represents the maximum in the range
        [Range(0, 999.99, ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Price { get; set; }
        //[MinimumYearValidatorAttribute]
        [MinimumYearValidatorAttribute(ErrorMessage ="Date of birth should not be newer than Jan 01, 2000")]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }
    

        // CUSTOM VALIDATIONS WITH MULTIPLE PROPERTIES 
        public DateTime FromDate { get; set; }
        [DateRangeValidator("FromDate", ErrorMessage = "From Date should be less than to date")]
        public DateTime ToDate { get; set; }

        public int? Age { get; set; }


        // IValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                // YIELD KEYWORD IS USED if you want to return multiple values
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied", 
                    new[] {nameof(Age)});
            }
        }
    }
}
