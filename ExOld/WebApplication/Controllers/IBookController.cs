using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public interface IBookController 
    {
        Task<ActionResult<IList<Author>>> GetBooks();
        Task<ActionResult<Book>> AddBook([FromBody] int AuthorId, Book book);
        Task<ActionResult<Book>> RemoveBook([FromBody] int ISBN);
    }
}