using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    public class CapacitiesController : Controller
    {
        private readonly HospitalManagementContext _context;

        public CapacitiesController(HospitalManagementContext context)
        {
            _context = context;
        }

        // GET: Capacities
        public async Task<IActionResult> Index()
        {
              return _context.Capacities != null ? 
                          View(await _context.Capacities.ToListAsync()) :
                          Problem("Entity set 'HospitalManagementContext.Capacities'  is null.");
        }

        // GET: Capacities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Capacities == null)
            {
                return NotFound();
            }

            var capacity = await _context.Capacities
                .FirstOrDefaultAsync(m => m.CapacityID == id);
            if (capacity == null)
            {
                return NotFound();
            }

            return View(capacity);
        }

        // GET: Capacities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capacities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapacityID,CapacityCount,Vacancy,Type")] Capacity capacity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacity);
        }

        // GET: Capacities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Capacities == null)
            {
                return NotFound();
            }

            var capacity = await _context.Capacities.FindAsync(id);
            if (capacity == null)
            {
                return NotFound();
            }
            return View(capacity);
        }

        // POST: Capacities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapacityID,CapacityCount,Vacancy,Type")] Capacity capacity)
        {
            if (id != capacity.CapacityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacityExists(capacity.CapacityID))
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
            return View(capacity);
        }

        // GET: Capacities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Capacities == null)
            {
                return NotFound();
            }

            var capacity = await _context.Capacities
                .FirstOrDefaultAsync(m => m.CapacityID == id);
            if (capacity == null)
            {
                return NotFound();
            }

            return View(capacity);
        }

        // POST: Capacities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Capacities == null)
            {
                return Problem("Entity set 'HospitalManagementContext.Capacities'  is null.");
            }
            var capacity = await _context.Capacities.FindAsync(id);
            if (capacity != null)
            {
                _context.Capacities.Remove(capacity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapacityExists(int id)
        {
          return (_context.Capacities?.Any(e => e.CapacityID == id)).GetValueOrDefault();
        }
    }
}
