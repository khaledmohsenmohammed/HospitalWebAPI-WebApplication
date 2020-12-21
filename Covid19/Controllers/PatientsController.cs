using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19.Data;
using Covid19.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Covid19.Controllers
{
    [Authorize(Roles = "administrator,admin,hospital")]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            applicationUser = await _context.applicationUsers
              .SingleOrDefaultAsync(m => m.Id == userId);
            var hospital = await _context.hospitals
               .FirstOrDefaultAsync(m => m.Id == applicationUser.HospitalId);
            if(hospital!=null)
            {
                ViewData["HospitalName"] = hospital.HName;
            }

            var applicationDbContext = _context.patients.Include(p => p.hospital);
            List<Patient> patients = await applicationDbContext.ToListAsync();
            foreach (Patient item in patients)
            {
                switch (item.StatusID)
                {
                    case 0:
                        item.StatusName = "جديد";
                        item.Statusclass = "label label-success label-mini";
                        break;
                    case 1:
                        item.StatusName = "تحسن";
                        item.Statusclass = "label label-warning label-mini";
                        break;
                    case 2:
                        item.StatusName = "شفاء";
                        item.Statusclass = "label label-info label-mini";
                        break;
                    case 3:
                        item.StatusName = "وفاه";
                        item.Statusclass = "label label-danger label-mini";
                        break;
                    case 4:
                        item.StatusName = "تحويل";
                        item.Statusclass = "label label-default label-mini";
                        break;
                    default:
                        // code block
                        break;
                }
                if (item.StatusID == 0)
                {
                    item.ExitDate0 = "";
                }
                else
                {
                    item.ExitDate0 = item.ExitDate.ToString();
                }
            }
            return View(patients);
        }

        // GET: New Patients 
        public async Task<IActionResult> NewPatients()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            applicationUser = await _context.applicationUsers
              .SingleOrDefaultAsync(m => m.Id == userId);
            var hospital = await _context.hospitals
               .FirstOrDefaultAsync(m => m.Id == applicationUser.HospitalId);
            if (hospital != null)
            {
                ViewData["HospitalName"] = hospital.HName;
            }

            var applicationDbContext = _context.patients.Include(p => p.hospital).Where(x => x.StatusID == 0);
            List<Patient> patients = await applicationDbContext.ToListAsync();
            foreach (Patient item in patients)
            {
                switch (item.StatusID)
                {
                    case 0:
                        item.StatusName = "جديد";
                        item.Statusclass = "label label-success label-mini";
                        break;
                    case 1:
                        item.StatusName = "تحسن";
                        item.Statusclass = "label label-warning label-mini";
                        break;
                    case 2:
                        item.StatusName = "شفاء";
                        item.Statusclass = "label label-info label-mini";
                        break;
                    case 3:
                        item.StatusName = "وفاه";
                        item.Statusclass = "label label-danger label-mini";
                        break;
                    case 4:
                        item.StatusName = "تحويل";
                        item.Statusclass = "label label-default label-mini";
                        break;
                    default:
                        // code block
                        break;
                }
                if (item.StatusID == 0)
                {
                    item.ExitDate0 = "";
                }
                else
                {
                    item.ExitDate0 = item.ExitDate.ToString();
                }
            }
            return View(patients);
        }
        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients
                .Include(p => p.hospital)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            switch (patient.StatusID)
            {
                case 0:
                    patient.StatusName = "جديد";
                    patient.Statusclass = "label label-success label-mini";
                    break;
                case 1:
                    patient.StatusName = "تحسن";
                    patient.Statusclass = "label label-warning label-mini";
                    break;
                case 2:
                    patient.StatusName = "شفاء";
                    patient.Statusclass = "label label-info label-mini";
                    break;
                case 3:
                    patient.StatusName = "وفاه";
                    patient.Statusclass = "label label-danger label-mini";
                    break;
                case 4:
                    patient.StatusName = "تحويل";
                    patient.Statusclass = "label label-default label-mini";
                    break;
                default:
                    // code block
                    break;
            }
            if (patient.StatusID == 0)
            {
                patient.ExitDate0 = "";
                ViewData["Divhide"] = "display: none;";
            }
            else
            {
                patient.ExitDate0 = patient.ExitDate.ToString();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ApplicationUser applicationUser { get; set; }
        [Authorize(Roles = "hospital")]
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
             applicationUser = await _context.applicationUsers
               .SingleOrDefaultAsync(m => m.Id == userId);
            ViewData["HospitalId"] = new SelectList(_context.hospitals, "Id", "HName", applicationUser.HospitalId.ToString());
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HospitalId,PName,NationalId,Age,Job,Address,TicketNumber,EnterDate,Onvent,Report,StatusID,ExitDate")] Patient patient)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            applicationUser = await _context.applicationUsers
              .SingleOrDefaultAsync(m => m.Id == userId);
            if (ModelState.IsValid)
            {
                patient.HospitalId = applicationUser.HospitalId;
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["HospitalId"] = new SelectList(_context.hospitals, "Id", "HName", applicationUser.HospitalId.ToString());
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            if (patient.StatusID == 0)
            {
                patient.ExitDate = DateTime.Now.Date;
            }
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="جديد", Value = "0",Selected =patient.StatusID==0?true:false },
        new SelectListItem{ Text="تحسن", Value = "1" ,Selected =patient.StatusID==1?true:false},
        new SelectListItem{ Text="شفاء", Value = "2" ,Selected =patient.StatusID==2?true:false},
        new SelectListItem{ Text="وفاه", Value = "3",Selected =patient.StatusID==3?true:false},
        new SelectListItem{ Text="تحويل", Value = "4",Selected =patient.StatusID==4?true:false},
    };
            ViewData["divhide"] = patient.StatusID == 0 ? "display: none;" : "";
            ViewData["statusList"] = list;
            ViewData["HospitalId"] = new SelectList(_context.hospitals, "Id", "HName", patient.HospitalId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,HospitalId,PName,NationalId,Age,Job,Address,TicketNumber,EnterDate,Onvent,Report,StatusID,ExitDate")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            applicationUser = await _context.applicationUsers
              .SingleOrDefaultAsync(m => m.Id == userId);
            if (ModelState.IsValid)
            {
                try
                {
                    patient.HospitalId = applicationUser.HospitalId;
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospitalId"] = new SelectList(_context.hospitals, "Id", "HName", patient.HospitalId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients
                .Include(p => p.hospital)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            switch (patient.StatusID)
            {
                case 0:
                    patient.StatusName = "جديد";
                    patient.Statusclass = "label label-success label-mini";
                    break;
                case 1:
                    patient.StatusName = "تحسن";
                    patient.Statusclass = "label label-warning label-mini";
                    break;
                case 2:
                    patient.StatusName = "شفاء";
                    patient.Statusclass = "label label-info label-mini";
                    break;
                case 3:
                    patient.StatusName = "وفاه";
                    patient.Statusclass = "label label-danger label-mini";
                    break;
                case 4:
                    patient.StatusName = "تحويل";
                    patient.Statusclass = "label label-default label-mini";
                    break;
                default:
                    // code block
                    break;
            }
            if (patient.StatusID == 0)
            {
                patient.ExitDate0 = "";
                ViewData["Divhide"] = "display: none;";
            }
            else
            {
                patient.ExitDate0 = patient.ExitDate.ToString();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var patient = await _context.patients.FindAsync(id);
            _context.patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int? id)
        {
            return _context.patients.Any(e => e.Id == id);
        }
    }
}
