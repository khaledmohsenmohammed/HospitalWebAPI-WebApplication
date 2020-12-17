using HospitalWebAPI.DbContexts;
using HospitalWebAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class AdminApplicationUserController : ControllerBase
    {
        private readonly HospitalContext hospitalContext;

        public AdminApplicationUserController(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
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
