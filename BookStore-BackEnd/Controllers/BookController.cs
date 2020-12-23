using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreDbContext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            try
            {
                if(_bookService.ReadAllBooks() == null)
                {
                    return NotFound();
                }
                return Ok(_bookService.ReadAllBooks());
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            try
            {
                if(id < 1)
                {
                    return BadRequest("Please enter correct id. Id must be bigger than 0");
                }
                return Ok(_bookService.GetBookById(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            try
            {
                return Ok(_bookService.CreateBook(book));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book book)
        {
            try
            {
                if(id < 1 || book.Id != id)
                {
                    return BadRequest("Ids must match and must be bigger than 0");
                }
                _bookService.UpdateBook(book);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            try
            {
                if(id < 1)
                {
                    return BadRequest("Enter correct id. Id should be bigger than 1");
                }
                return Ok(_bookService.DeleteBook(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
