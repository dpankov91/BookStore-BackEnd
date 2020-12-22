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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            try
            {
                if(_authorService.ReadAllAuthors() != null)
                {
                    return Ok(_authorService.ReadAllAuthors());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            try
            {
                if(id < 1)
                {
                    return BadRequest("Id must be bigger than 0");
                }
                return Ok(_authorService.ReadAuthorById(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<AuthorController>
        [HttpPost]
        public ActionResult<Author> Post([FromBody] Author author)
        {
            try
            {
                return Ok(_authorService.CreateAuthor(author));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public ActionResult<Author> Put(int id, [FromBody] Author author)
        {
            try
            {
                if(id < 1 || author.Id != id)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                return _authorService.UpdateAuthor(author);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            try
            {
                if(id < 1)
                {
                    return BadRequest("Enter correct id. ID must be bigger than 1");
                }
                _authorService.DeleteAuthor(id);
                return Ok("Author with id:" + id + " successfully deleted");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
