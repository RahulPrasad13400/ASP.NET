using _11.ModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace _11.ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookId?}")] // if we put a question mark like bookId? - then it becomes nullable
        //public IActionResult Index(int bookId)
        // https://localhost:7082/bookstore/3?bookName=abc
        public IActionResult Index(int? bookId, string bookName) // if we put a question mark infront of int then it become nullable
        {   
            if (!bookId.HasValue) return BadRequest("BookId is not supplied or is Empty");
            if (bookId <= 0) return BadRequest("BookId can't be less than or equal to zero");
            return Content($"Book Id is : {bookId} - Book Name is {bookName}");
        }


        // https://localhost:7082/book?Id=4&Name=hello
        [Route("book")] 
        public IActionResult Book(Book book) 
        {
            return Content($"Book Id : {book.Id} and book Name : {book.Name}");
        }
    }
}


//[FromQuery] - To get the value from the query string 
//[FromRoute] - To get the value from the route parameters only 