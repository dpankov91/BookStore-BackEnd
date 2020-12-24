using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                if (_userService.GetAllUsers() != null)
                {
                    return Ok(_userService.GetAllUsers());
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            { 
                if (_userService.GetAllUsers() != null)
                {
                return Ok(_userService.GetUserById(id));
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
    }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                return Ok(_userService.CreateUser(user));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            try
            {
                if (id < 1 || user.Id != id)
                {
                    return BadRequest("Please enter correct id. Id must be bigger than 0");
                }
                return Ok(_userService.UpdateUser(user));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Please enter correct id. Id must be bigger than 0");
                }
                _userService.DeleteUser(id);
                return Ok("User with id:" + id + " successfully deleted");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
