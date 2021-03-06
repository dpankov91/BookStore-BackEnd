﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.Entities;
using BookStore.Core.ISecurity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private IAuthenticationHelper _authHelper;

        public TokenController(IUserService userService, IAuthenticationHelper authenticationHelper)
        {
            _userService = userService;
            _authHelper = authenticationHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(u => u.Username == model.Username);

            //Cheking if user exists
            if (user == null)
                return Unauthorized();

            //Chek if pass is correct
            if (!_authHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            //Authentication successfull
            return Ok(new
            {
                username = user.Username,
                token = _authHelper.GenerateToken(user)
            });
        }
    }
}
