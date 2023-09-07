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
    public class BillingsController : Controller
    {
        private readonly HospitalManagementContext _context;

        public BillingsController(HospitalManagementContext context)
        {
            _context = context;
        }

        // GET: Billings
        public async Task<IActionResult> Index()
        {
              return _context.Billings != null ? 
                          View(await _context.Billings.ToListAsync()) :
                          Problem("Entity set 'HospitalManagementContext.Billings'  is null.");
        }

        // GET: Billings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Billings == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings
                .FirstOrDefaultAsync(m => m.BillingID == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // GET: Billings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillingID,PatientID,BillDate,TotalAmount,PaymentStatus,PaymentMethod,RoomCharges,MedicationCharges,LabTestCharges,SurgeryCharges,OtherCharges")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billing);
        }

        // GET: Billings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Billings == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillingID,PatientID,BillDate,TotalAmount,PaymentStatus,PaymentMethod,RoomCharges,MedicationCharges,LabTestCharges,SurgeryCharges,OtherCharges")] Billing billing)
        {
            if (id != billing.BillingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingExists(billing.BillingID))
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
            return View(billing);
        }

        // GET: Billings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Billings == null)
            {
                return NotFound();
            }

            var billing = await _context.Billings
                .FirstOrDefaultAsync(m => m.BillingID == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Billings == null)
            {
                return Problem("Entity set 'HospitalManagementContext.Billings'  is null.");
            }
            var billing = await _context.Billings.FindAsync(id);
            if (billing != null)
            {
                _context.Billings.Remove(billing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingExists(int id)
        {
          return (_context.Billings?.Any(e => e.BillingID == id)).GetValueOrDefault();
        }
    }
}
