using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using First_Project.Data;
using First_Project.Models;

namespace First_Project.Controllers
{
    public class BUMONsController : Controller
    {
        private readonly First_ProjectContext _context;

        public BUMONsController(First_ProjectContext context)
        {
            _context = context;
        }

        // GET: BUMONs
        public async Task<IActionResult> Index()
        {
              return _context.BUMON != null ? 
                          View(await _context.BUMON.ToListAsync()) :
                          Problem("Entity set 'First_ProjectContext.BUMON'  is null.");
        }

        // GET: BUMONs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BUMON == null)
            {
                return NotFound();
            }

            var bUMON = await _context.BUMON
                .FirstOrDefaultAsync(m => m.BUMONCD == id);
            if (bUMON == null)
            {
                return NotFound();
            }

            return View(bUMON);
        }

        // GET: BUMONs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BUMONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BUMONCD,BUMONNM")] BUMON bUMON)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bUMON);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bUMON);
        }

        // GET: BUMONs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BUMON == null)
            {
                return NotFound();
            }

            var bUMON = await _context.BUMON.FindAsync(id);
            if (bUMON == null)
            {
                return NotFound();
            }
            return View(bUMON);
        }

        // POST: BUMONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BUMONCD,BUMONNM")] BUMON bUMON)
        {
            if (id != bUMON.BUMONCD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bUMON);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BUMONExists(bUMON.BUMONCD))
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
            return View(bUMON);
        }

        // GET: BUMONs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BUMON == null)
            {
                return NotFound();
            }

            var bUMON = await _context.BUMON
                .FirstOrDefaultAsync(m => m.BUMONCD == id);
            if (bUMON == null)
            {
                return NotFound();
            }

            return View(bUMON);
        }

        // POST: BUMONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BUMON == null)
            {
                return Problem("Entity set 'First_ProjectContext.BUMON'  is null.");
            }
            var bUMON = await _context.BUMON.FindAsync(id);
            if (bUMON != null)
            {
                _context.BUMON.Remove(bUMON);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BUMONExists(string id)
        {
          return (_context.BUMON?.Any(e => e.BUMONCD == id)).GetValueOrDefault();
        }
    }
}
