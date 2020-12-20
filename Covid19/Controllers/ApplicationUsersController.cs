using Covid19.Data;
using Covid19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Covid19.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ApplicationUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

    }
}
