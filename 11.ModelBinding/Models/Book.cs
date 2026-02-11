using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _11.ModelBinding.Models
{
    public class Book
    {
        [FromQuery] // we can specify like this, it shows where the value is actually coming from 
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public override string ToString()
        {
            return $"BookId : {Id} - Book Name : {Name}";
        }
    }
}
