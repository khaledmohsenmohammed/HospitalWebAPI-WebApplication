using HospitalWepAppMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWepAppMVC.Controllers
{
    public class AccountController1 : Controller
    {
        private UserManager<AppUser> userMgr;
        private SignInManager<AppUser> signInMgr;
        public AccountController1(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            userMgr = userManager;
            signInMgr = signInManager;

        } 

        public async Task<IActionResult> Login()
        {
            var result = await signInMgr.PasswordSignInAsync("", "", false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is" + result.ToString();
            }
            return View();
        }
        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";
                AppUser user = await userMgr.FindByNameAsync("testuser");
                if(user==null)
                {
                    user = new AppUser();
                    user.UserName = "admin";
                    user.Email = "email@test.com";
                    user.FullName = "test";
                    IdentityResult result = await userMgr.CreateAsync(user, "123456");
                    ViewBag.Message = "User created";

                }

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }
            return View();
        }

    }
}
