using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Identity;
using AnimalHealthBookApi.Dto;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AHBContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;


        public UsersController(
            AHBContext context, 
            SignInManager<User> signInManager,
            UserManager<User> userManager
            )
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // POST register user, override the same default implementation
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserCreationDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Email,
            };


            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            //return a user object with jwt token

            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                return BadRequest(result.Errors);
            }


            //return token  





            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok();
        }

        
    }
}
