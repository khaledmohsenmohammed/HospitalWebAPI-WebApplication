using HospitalWebAPI.DbContexts;
using HospitalWebAPI.Helpers;
using HospitalWebAPI.Models.Entities;
using HospitalWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWebAPI.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class AdminApplicationUserController : ControllerBase
    {
        private readonly HospitalContext hospitalContext;
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        public AdminApplicationUserController(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AdminApplicationUser userDto)
        {
            var user = _userService.Authenticate(userDto.UserName, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                TypeOfJop = user.TypeOfJop,
                Token = tokenString
            });
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var user = hospitalContext.AdminApplicationUser.ToList();
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById (int userId)
        {
            var user = hospitalContext.AdminApplicationUser.Find(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("api/users/create")]
        public IActionResult CreateUser (AdminApplicationUser usereData)
        {
            hospitalContext.AdminApplicationUser.Add(usereData);
            hospitalContext.SaveChanges();
            return Ok(usereData);
        }

        [HttpDelete("{userId}")]
        public IActionResult DeletUser(int userId)
        {
            var user = hospitalContext.AdminApplicationUser.Find(userId);
            if (user == null)
            {
                return NotFound("this User not found");
            }
            hospitalContext.AdminApplicationUser.Remove(user);
            hospitalContext.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(AdminApplicationUser userdata)
        {
            var user = hospitalContext.AdminApplicationUser.Find(userdata.Id);
            if (user == null)
            {
                return NotFound("this user not found");
            }
            user.UserName = userdata.UserName;
            user.Password = userdata.Password;
            hospitalContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            hospitalContext.SaveChanges();
            return Ok(user);
        }


    }
}
