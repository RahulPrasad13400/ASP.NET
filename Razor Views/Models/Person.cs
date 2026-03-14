namespace Razor_Views.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<string>? FavouriteMovies { get; set; }
    }
    public enum Gender
    {
        Male, 
        Female,
        Other
    }
}
