using Covid19.Data;
using Covid19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.applicationUsers.ToListAsync());
        }


        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.applicationUsers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: Hospitals
        public async Task<IActionResult> hospital  ()
        {
            return View(await _context.hospitals.ToListAsync());
        }

        // GET: ApplicationUsers/Create
        public async Task<IActionResult> Create()
        {
            ViewData["HospitalId"] = new SelectList(_context.hospitals, "Id", "HName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateofBirth,Url,Id,UserName,Email,Passwor,HospitalId")] ApplicationUser applicationUser)
        {

            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }






        //private readonly UserManager<ApplicationUser> _userManager;
        //public ApplicationUsersController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var users = _userManager.Users;
        //    return View(users);
        //}

    }
}
