using HospitalWepAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWepAppMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _Configure;
        private string apiBaseUrl;
        public LoginController(IConfiguration configuration)
        {
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpGet]
        public ActionResult Index()
        {
            AdminApplicationUser user = new AdminApplicationUser();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminApplicationUser user)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/login";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        TempData["Profile"] = JsonConvert.SerializeObject(user);

                        return RedirectToAction("Profile");

                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");
                        return View();

                    }

                }
            }
        }
    }
}
