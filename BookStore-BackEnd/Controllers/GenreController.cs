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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        // GET: api/<GenreController>
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            try
            {
                if (_genreService.ReadAllGenres() != null)
                {
                    return Ok(_genreService.ReadAllGenres());
                }
                return StatusCode(404, "No Genres in database");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error when trying to get all genre from database");
            }
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GenreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
