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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
