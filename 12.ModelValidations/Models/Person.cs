using System.ComponentModel.DataAnnotations;

namespace _12.ModelValidations.Models
{
    public class Person
    {
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public double? Price { get; set; }
    }
}
