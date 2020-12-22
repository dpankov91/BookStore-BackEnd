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
                return NotFound();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            try
            {
                if(id < 1 || id.Equals(null))
                {
                    return StatusCode(500, "Please enter correct id. Id cant be less than 1");
                }
                if(_genreService.ReadGenreById(id) == null)
                {
                    return NotFound();
                }
                return Ok(_genreService.ReadGenreById(id));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<GenreController>
        [HttpPost]
        public ActionResult<Genre> Post([FromBody] Genre genre)
        {
            try
            {
                return Ok(_genreService.CreateGenre(genre));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
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
