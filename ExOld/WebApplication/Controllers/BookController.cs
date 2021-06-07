using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController: ControllerBase, IBookController
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetBooks()
        {
            try
            {
               IList<Book> valid = await bookService.GetBooks();
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{AuthorId:int}")]
        public async Task<ActionResult<Book>> AddBook([FromRoute]int AuthorId,[FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Book valid = await bookService.AddBook(AuthorId, book);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{ISBN:int}")]
        public async Task<ActionResult<Book>> RemoveBook([FromRoute]int ISBN)
        {
            try
            {
                Book valid = await bookService.DeleteBook(ISBN);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}