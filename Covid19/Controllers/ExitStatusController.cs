using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19.Data;
using Covid19.Models;

namespace Covid19.Controllers
{
    public class ExitStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExitStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExitStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExitStatus.ToListAsync());
        }

        // GET: ExitStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exitStatus = await _context.ExitStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exitStatus == null)
            {
                return NotFound();
            }

            return View(exitStatus);
        }

        // GET: ExitStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExitStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] ExitStatus exitStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exitStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exitStatus);
        }

        // GET: ExitStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exitStatus = await _context.ExitStatus.FindAsync(id);
            if (exitStatus == null)
            {
                return NotFound();
            }
            return View(exitStatus);
        }

        // POST: ExitStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,StatusName")] ExitStatus exitStatus)
        {
            if (id != exitStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exitStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExitStatusExists(exitStatus.Id))
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
            return View(exitStatus);
        }

        // GET: ExitStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exitStatus = await _context.ExitStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exitStatus == null)
            {
                return NotFound();
            }

            return View(exitStatus);
        }

        // POST: ExitStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var exitStatus = await _context.ExitStatus.FindAsync(id);
            _context.ExitStatus.Remove(exitStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExitStatusExists(int? id)
        {
            return _context.ExitStatus.Any(e => e.Id == id);
        }
    }
}
