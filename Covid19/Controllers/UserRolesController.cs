using Covid19.Data;
using Covid19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        //private RoleManager<IdentityRole> _roleManager;


        public UserRolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult CreateAsync() => View();

        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(string Email, string RoleName)

        {
            try
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(Email);
               
                await _userManager.AddToRoleAsync(user, RoleName);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
    }
}
