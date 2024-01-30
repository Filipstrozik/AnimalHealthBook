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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YourSecretKeyHere"); // Replace with your secret key

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                // Add more claims if needed
            };

            // Add user roles as claims
            var userRoles = _userManager.GetRolesAsync(user).Result;
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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

            var token = GenerateJwtToken(user);

            var userToReturn = new
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = "User",
                Token = token
            };

            return Ok(userToReturn);
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

            //return a user object with jwt token
            var token = GenerateJwtToken(user);

            var userToReturn = new 
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };

            return Ok(userToReturn);
        }

        
    }
}
