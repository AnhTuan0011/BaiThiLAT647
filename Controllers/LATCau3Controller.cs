using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BAITHILAT0647.Models;
using BAITHILAT0647.Models.Process;

namespace BAITHILAT0647.Controllers
{
    public class LATCau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        Toup ad = new Toup();

        public LATCau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LATCau3
        public async Task<IActionResult> Index()
        {
              return _context.LATCau3 != null ? 
                          View(await _context.LATCau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LATCau3'  is null.");
        }

        // GET: LATCau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LATCau3 == null)
            {
                return NotFound();
            }

            var lATCau3 = await _context.LATCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (lATCau3 == null)
            {
                return NotFound();
            }

            return View(lATCau3);
        }

        // GET: LATCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LATCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,Address")] LATCau3 lATCau3)
        {
            if (ModelState.IsValid)
            {
                lATCau3.StudentName = ad.addToupper(lATCau3.StudentName);
                _context.Add(lATCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lATCau3);
        }

        // GET: LATCau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LATCau3 == null)
            {
                return NotFound();
            }

            var lATCau3 = await _context.LATCau3.FindAsync(id);
            if (lATCau3 == null)
            {
                return NotFound();
            }
            return View(lATCau3);
        }

        // POST: LATCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName,Address")] LATCau3 lATCau3)
        {
            if (id != lATCau3.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lATCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LATCau3Exists(lATCau3.StudentID))
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
            return View(lATCau3);
        }

        // GET: LATCau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LATCau3 == null)
            {
                return NotFound();
            }

            var lATCau3 = await _context.LATCau3
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (lATCau3 == null)
            {
                return NotFound();
            }

            return View(lATCau3);
        }

        // POST: LATCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LATCau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LATCau3'  is null.");
            }
            var lATCau3 = await _context.LATCau3.FindAsync(id);
            if (lATCau3 != null)
            {
                _context.LATCau3.Remove(lATCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LATCau3Exists(string id)
        {
          return (_context.LATCau3?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
