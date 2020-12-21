using Covid19.Data;
using Covid19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    [Authorize(Roles = "administrator,admin,hospital")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ApplicationUser applicationUser { get; set; }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            applicationUser = await _context.applicationUsers
              .SingleOrDefaultAsync(m => m.Id == userId);

            int totalbeds = 0;
            int freebeds = 0;
            int totalvent = 0;
            int onvent = 0;
            int freevent = 0;
            string hname = "";
            List<Hospital> hospitals = await _context.hospitals.ToListAsync();
            Hospital result = hospitals.Find(x => x.Id == applicationUser.HospitalId);
            List<homestatistics> homestatistics = new List<homestatistics>();
            if (result!=null)
            {
                hname = result.HName;
                if (result.IsAdmin==true)
                {
                    foreach (Hospital item in hospitals)
                    {
                        totalbeds += item.ICUBeds;
                        totalvent += item.ICUVents;
                        if (item.ICUBeds > 0)
                        {
                            homestatistics homestatistics1 = new homestatistics();
                            homestatistics1.HospitalId = int.Parse(item.Id.ToString());
                            homestatistics1.hospitaname = item.HName;
                            homestatistics1.subtitle = "نسبة شغل الاسرة";
                            homestatistics1.bedicon = "hbed.png";
                            homestatistics1.classname = "info";
                            homestatistics1.total = item.ICUBeds;
                            homestatistics.Add(homestatistics1);

                             homestatistics1 = new homestatistics();
                            homestatistics1.HospitalId = int.Parse(item.Id.ToString());
                            homestatistics1.hospitaname = item.HName;
                            homestatistics1.subtitle = "نسبة شغل التنفس";
                            homestatistics1.bedicon = "hvent.png";
                            homestatistics1.classname = "success";
                            homestatistics1.total = item.ICUBeds;
                            homestatistics.Add(homestatistics1);
                        }
                    }
                    List<Patient> patients = await _context.patients.Where(x => x.StatusID == 0).ToListAsync();
                    freebeds = totalbeds- patients.Count;
                    foreach (Patient patient in patients)
                    {
                        if(patient.Onvent)
                        {
                            onvent += 1;
                            foreach (homestatistics h in homestatistics)
                            {
                                if (patient.HospitalId == h.HospitalId && h.classname == "success")
                                {
                                    h.countitems += 1;
                                }
                            }
                        }
                        foreach (homestatistics h in homestatistics)
                        {
                            if (patient.HospitalId == h.HospitalId && h.classname == "info")
                            {
                                h.countitems += 1;
                            }
                        }
                    }
                    foreach (homestatistics h in homestatistics)
                    {
                        double p= (h.countitems / h.total)*100;
                        h.percentage =Math.Round( p,2);
                    }
                        freevent = totalvent - onvent;

                }
                else
                {
                    totalbeds = result.ICUBeds;
                    totalvent = result.ICUVents;
                    List<Patient> patients = await _context.patients.Where(x => x.StatusID == 0 & x.HospitalId==applicationUser.HospitalId).ToListAsync();
                    if (result.ICUBeds > 0)
                    {
                        homestatistics homestatistics1 = new homestatistics();
                        homestatistics1.HospitalId = int.Parse(result.Id.ToString());
                        homestatistics1.hospitaname = result.HName;
                        homestatistics1.subtitle = "نسبة شغل الاسرة";
                        homestatistics1.bedicon = "hbed.png";
                        homestatistics1.classname = "info";
                        homestatistics1.total = result.ICUBeds;
                        homestatistics.Add(homestatistics1);

                        homestatistics1 = new homestatistics();
                        homestatistics1.HospitalId = int.Parse(result.Id.ToString());
                        homestatistics1.hospitaname = result.HName;
                        homestatistics1.subtitle = "نسبة شغل التنفس";
                        homestatistics1.bedicon = "hvent.png";
                        homestatistics1.classname = "success";
                        homestatistics1.total = result.ICUBeds;
                        homestatistics.Add(homestatistics1);
                    }

                    foreach (Patient patient in patients)
                    {
                        if (patient.Onvent)
                        {
                            onvent += 1;
                            foreach (homestatistics h in homestatistics)
                            {
                                if (patient.HospitalId == h.HospitalId && h.classname == "success")
                                {
                                    h.countitems += 1;
                                }
                            }
                        }
                        foreach (homestatistics h in homestatistics)
                        {
                            if (patient.HospitalId == h.HospitalId && h.classname == "info")
                            {
                                h.countitems += 1;
                            }
                        }
                    }
                    foreach (homestatistics h in homestatistics)
                    {
                        double p = (h.countitems / h.total) * 100;
                        h.percentage = Math.Round(p, 2);
                    }
                    freevent = totalvent - onvent;
                    freebeds = totalbeds - patients.Count;
                }
            }

            



            ViewData["hname"] = hname;
            ViewData["totalbes"] = totalbeds;
            ViewData["freebeds"] = freebeds;
            ViewData["totalvent"] = totalvent;
            ViewData["freevent"] = freevent;
            
            return View(homestatistics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
