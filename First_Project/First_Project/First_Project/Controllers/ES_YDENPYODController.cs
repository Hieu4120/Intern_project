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
    public class ES_YDENPYODController : Controller
    {
        private readonly First_ProjectContext _context;

        public ES_YDENPYODController(First_ProjectContext context)
        {
            _context = context;
        }


        // GET: ES_YDENPYOD
        public async Task<IActionResult> Index()
        {
            var es_d = from m in _context.ES_YDENPYOD
                     select m;
            var ES_YDENPYOD = new ES_YDENPYODViewModel
            {               
                ES_YDENPYOD = await es_d.ToListAsync()
            };
            return View(ES_YDENPYOD);
        }

        // GET: ES_YDENPYOD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ES_YDENPYOD == null)
            {
                return NotFound();
            }

            var eS_YDENPYOD = await _context.ES_YDENPYOD
                .FirstOrDefaultAsync(m => m.GYONO == id);
            if (eS_YDENPYOD == null)
            {
                return NotFound();
            }

            return View(eS_YDENPYOD);
        }

        // GET: ES_YDENPYOD/Create
        public async Task< IActionResult> Create(int id, int parent_id,  ES_YDENPYODViewModel C_ES_YDENPYOD)
        {
            var ces = from m in _context.ES_YDENPYOD
                      where m.GYONO == id
                      select m;
            string myurl = HttpContext.Request.QueryString.ToString();
            string myurl2 = HttpContext.Request.QueryString.ToString();
            Console.WriteLine("FIRSTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
            var C_ES_YDENPYOD1 = new ES_YDENPYODViewModel
            {
                myurl2 = myurl2,
                myurl = myurl,
                parent_id = parent_id,
                ES_YDENPYOD1 = await ces.FirstOrDefaultAsync(m => m.GYONO == id),
            };
            
            if (C_ES_YDENPYOD1.ES_YDENPYOD1 == null)
            {
                
                C_ES_YDENPYOD1.ES_YDENPYOD1 = new ES_YDENPYOD();
               

            }
            /*Console.WriteLine(id);*/
            return View(C_ES_YDENPYOD1);
        }

        // POST: ES_YDENPYOD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Create( ES_YDENPYODViewModel C_ES_YDENPYOD)
        {
            Console.WriteLine("HIIIIIIIIIIIIIIIIIIIIIIIIIIII");
            var C_ES_YDENPYOD1 = new ES_YDENPYODViewModel
            {
                ES_YDENPYOD1 = C_ES_YDENPYOD.ES_YDENPYOD1,
                         
            };
           
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.IDODT);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.SHUPPATSUPLC);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.MOKUTEKIPLC);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.KEIRO);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.KINGAKU);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.GYONO);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.DENPYONO);

            if (C_ES_YDENPYOD1.ES_YDENPYOD1.GYONO == 0)
            {
                C_ES_YDENPYOD1.ES_YDENPYOD1.DENPYONO = C_ES_YDENPYOD.parent_id;
            }
           
            _context.ES_YDENPYOD.Update(C_ES_YDENPYOD1.ES_YDENPYOD1);
           
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));           
        }

        // GET: ES_YDENPYOD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.ES_YDENPYOD == null)
            {
                return NotFound();
            }


            var eS_YDENPYOD = await _context.ES_YDENPYOD.FindAsync(id);
            if (eS_YDENPYOD == null)
            {
                return NotFound();
            }
            return View(eS_YDENPYOD);
        }

        // POST: ES_YDENPYOD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Edit(ES_YDENPYODViewModel C_ES_YDENPYOD)
        {
            Console.WriteLine("HIIIIIIIIIIIIIIIIIIIIIIIIIIII");
            var C_ES_YDENPYOD1 = new ES_YDENPYODViewModel
            {
                ES_YDENPYOD1 = C_ES_YDENPYOD.ES_YDENPYOD1,
            };
            Console.WriteLine(C_ES_YDENPYOD1.parent_id + "AAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBB");
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.IDODT);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.SHUPPATSUPLC);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.MOKUTEKIPLC);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.KEIRO);
            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.KINGAKU);
            C_ES_YDENPYOD1.ES_YDENPYOD1.DENPYONO = C_ES_YDENPYOD.parent_id;
            _context.Update(C_ES_YDENPYOD1.ES_YDENPYOD1);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: ES_YDENPYOD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ES_YDENPYOD == null)
            {
                return NotFound();
            }

            var eS_YDENPYOD = await _context.ES_YDENPYOD
                .FirstOrDefaultAsync(m => m.GYONO == id);
            if (eS_YDENPYOD == null)
            {
                return NotFound();
            }

            return View(eS_YDENPYOD);
        }

        // POST: ES_YDENPYOD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ES_YDENPYOD == null)
            {
                return Problem("Entity set 'First_ProjectContext.ES_YDENPYOD'  is null.");
            }
            var eS_YDENPYOD = await _context.ES_YDENPYOD.FindAsync(id);
            if (eS_YDENPYOD != null)
            {
                _context.ES_YDENPYOD.Remove(eS_YDENPYOD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ES_YDENPYODExists(int id)
        {
          return (_context.ES_YDENPYOD?.Any(e => e.GYONO == id)).GetValueOrDefault();
        }
    }
}
