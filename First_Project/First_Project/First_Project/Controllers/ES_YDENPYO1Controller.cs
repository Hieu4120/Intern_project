using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using First_Project.Data;
using graduate_project.Models;
using First_Project.Models;

namespace First_Project.Controllers
{
    public class ES_YDENPYO1Controller : Controller
    {
        private readonly First_ProjectContext _context;

        public ES_YDENPYO1Controller(First_ProjectContext context)
        {
            _context = context;
        }
        // GET: ES_YDENPYO1
        public async Task<IActionResult> Index(string SearchSelect, string Document_id_from, string Document_id_to, string Document_date_from,
                                                string Document_date_to, string application_date_from, string application_date_to,
                                                string SearchSelect_cash_start, string SearchSelect_cash_end)
        {
            var es = from m in _context.ES_YDENPYO
                     select m;
            var year = from m in _context.ES_YDENPYO                       
                       select m.KAIKEIND;
            var cash_method = from m in _context.ES_YDENPYO
                              select m.SUITOKB;
            var doc_date = from m in _context.ES_YDENPYO
                           select m.DENPYODT;
           
            ///
            var date_max_id = DateTime.Now.ToString();
            var date_min_id = DateTime.Now.ToString();
            var doc_date_max_id = DateTime.Now;
            var doc_date_min_id = DateTime.Now;
            try
            {
                date_max_id = es.Max(m => m.UKETUKEDT);
                date_min_id = es.Min(m => m.UKETUKEDT);
                doc_date_max_id = es.Max(m => m.DENPYODT);
                doc_date_min_id = es.Min(m => m.DENPYODT);
            }
            catch (Exception e)
            { 
                Console.WriteLine("Can not find id");
            }
                if (!string.IsNullOrEmpty(application_date_from) || !string.IsNullOrEmpty(application_date_to))
                {
                    if (string.IsNullOrEmpty(application_date_from))
                    {
                        application_date_from = date_min_id;
                    }
                    else
                    {
                        ViewData["application_date_from"] = application_date_from;
                    }
                    if (string.IsNullOrEmpty(application_date_to))
                    {
                        application_date_to = date_max_id;

                    }
                    else
                    {
                        ViewData["application_date_to"] = application_date_to;
                    }

                    es = from m in _context.ES_YDENPYO.FromSqlInterpolated($"SELECT * FROM ES_YDENPYO  WHERE UKETUKEDT >= {application_date_from} AND UKETUKEDT <= {application_date_to} ")
                         select m;
                }

                ////
                ///
                if (!string.IsNullOrEmpty(Document_date_from) || !string.IsNullOrEmpty(Document_date_to))
                {
                    if (string.IsNullOrEmpty(Document_date_from))
                    {
                        Document_date_from = doc_date_min_id.ToString();
                    }
                    else
                    {
                        ViewData["Document_date_from"] = Document_date_from;
                    }
                    if (string.IsNullOrEmpty(Document_date_to))
                    {
                        Document_date_to = doc_date_max_id.ToString();
                    }
                    else
                    {
                        ViewData["Document_date_to"] = Document_date_to;
                    }

                    es = es.Where(m => m.DENPYODT >= DateTime.Parse(Document_date_from) && m.DENPYODT <= DateTime.Parse(Document_date_to));
                }
            



            ///

            if (!string.IsNullOrEmpty(SearchSelect))
            { 
                es = es.Where(s => s.KAIKEIND == Int32.Parse(SearchSelect));
            }
            if (!string.IsNullOrEmpty(SearchSelect_cash_start) || !string.IsNullOrEmpty(SearchSelect_cash_start))
            {
                es = es.Where(s => s.SUITOKB.Contains( SearchSelect_cash_start) || s.SUITOKB.Contains(SearchSelect_cash_end));               
            }
          

            ////
            if (!string.IsNullOrEmpty(Document_id_from))
            {
                ViewData["Document_id_from"] = Document_id_from;                               
                    es = es.Where(s => s.DENPYONO >= Int32.Parse(Document_id_from));                    
            }

            if (!string.IsNullOrEmpty(Document_id_to))
            {               
                ViewData["Document_id_to"] = Document_id_to;
                es = es.Where(s => s.DENPYONO <= Int32.Parse(Document_id_to));
            }



           

            var pro_ES_YDENPYO = new ES_YDENPYO1ViewModel
            {
                KAIKEIND = new SelectList(await year.Distinct().OrderBy(s => s.Value).ToListAsync()),
                SUITOKB = new SelectList(await cash_method.Distinct().ToListAsync()),
                ES_YDENPYO = await es.ToListAsync(),
            };
            


            return _context.ES_YDENPYO != null ?
                          View(pro_ES_YDENPYO) :
                          Problem("Entity set 'First_ProjectContext.ES_YDENPYO'  is null.");

        }

        // GET: ES_YDENPYO1/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var es = from m in _context.ES_YDENPYO
                     select m;
            var eS_YDENPYO = await _context.ES_YDENPYO
               .FirstOrDefaultAsync(m => m.DENPYONO == id);
            var view = new ES_YDENPYO1ViewModel
            {
                ES_YDENPYO1 = eS_YDENPYO,

                ES_YDENPYO = await es.ToListAsync()
            };
            return View(view);

        }

        // GET: ES_YDENPYO1/Create
        public async Task<IActionResult> Create(string search_string_popup, string search_id_popup)
        {
            var ces = from m in _context.ES_YDENPYO
                      select m;
            var year = from m in _context.ES_YDENPYO
                       select m.KAIKEIND;
            var cash_method = from m in _context.ES_YDENPYO
                              select m.SUITOKB;
            var table_popup = from m in _context.BUMON
                              select m;
           

            var doc_num = _context.ES_YDENPYO.Max(m => m.DENPYONO) + 1;

            var ES = new ES_YDENPYO1();
            if (!String.IsNullOrEmpty(search_string_popup))
            {
                table_popup = table_popup.Where(s => s.BUMONNM!.Contains(search_string_popup));

            }

            if (!String.IsNullOrEmpty(search_id_popup))
            {
                table_popup = table_popup.Where(s => s.BUMONCD! == (search_id_popup));

            }

            var C_ES_YDENPYO = new ES_YDENPYO1ViewModel
            {
                KAIKEIND = new SelectList(await year.Distinct().ToListAsync()),
                SUITOKB = new SelectList(await cash_method.Distinct().ToListAsync()),
                BUMON = await table_popup.ToListAsync(),
                Max_id = doc_num,
                ES_YDENPYO1 = ES

            };

            return View(C_ES_YDENPYO);
        }
        // POST: ES_YDENPYO1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Create(ES_YDENPYO1ViewModel C_ES_YDENPYO)
        {                  
            var C_ES_YDENPYO1 = new ES_YDENPYO1ViewModel
            {
                ES_YDENPYO1 = C_ES_YDENPYO.ES_YDENPYO1,

            };
           /* C_ES_YDENPYO1.ES_YDENPYO1.UKETUKEDT = DateTime.Now.ToString();*/
            _context.Add(C_ES_YDENPYO.ES_YDENPYO1);

            if (await _context.SaveChangesAsync() > 0)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(C_ES_YDENPYO1);
        }

        // GET: ES_YDENPYO1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var year = from m in _context.ES_YDENPYO
                       select m.KAIKEIND;
            var cash_method = from m in _context.ES_YDENPYO
                              select m.SUITOKB;
            var table_popup = from m in _context.BUMON
                              select m;
            var doc_num_edit = from m in _context.ES_YDENPYO where m.DENPYONO == id
                               select m.DENPYONO;
            var es_d = from n in _context.ES_YDENPYOD
                       where n.DENPYONO == id
                       select n;
         

            if (id == null || _context.ES_YDENPYO == null)
            {
                return NotFound();
            }

            var eS_YDENPYO = await _context.ES_YDENPYO.FindAsync(id);
            var bu_name = from m in _context.BUMON
                          where m.BUMONCD == eS_YDENPYO.BUMONCD_YKANR
                          select m.BUMONNM;
            if (eS_YDENPYO == null)
            {
                return NotFound();
            }
            var C_ES_YDENPYO1 = new ES_YDENPYO1ViewModel
            {
                KAIKEIND = new SelectList(await year.Distinct().ToListAsync()),
                SUITOKB = new SelectList(await cash_method.Distinct().ToListAsync()),
                BUMON = await table_popup.ToListAsync(),
                ES_YDENPYO1 = eS_YDENPYO,
                Max_id_edit = doc_num_edit.FirstOrDefault(),
                ES_YDENPYOD = await es_d.ToListAsync(),
                Bumon_name = bu_name.FirstOrDefault()
            };

            return View("Create", C_ES_YDENPYO1);
        }

        // POST: ES_YDENPYO1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Edit(int id, ES_YDENPYO1ViewModel eS_YDENPYO)
        {
            eS_YDENPYO.ES_YDENPYO1.DENPYONO = id;
            var C_ES_YDENPYO1 = new ES_YDENPYO1ViewModel
            {
                ES_YDENPYO1 = eS_YDENPYO.ES_YDENPYO1,
                
            };
            Console.WriteLine(id + "cccccccccccccccccccccc");
            Console.WriteLine(eS_YDENPYO.ES_YDENPYO1.DENPYONO  + "cccccccccccccccccccccc");

           /* C_ES_YDENPYO1.ES_YDENPYO1.DENPYODT = int.Parse(DateTime.Now.ToString("dd"));*/

            /*  if (ModelState.IsValid)
              {*/
            try
            {
                _context.Update(eS_YDENPYO.ES_YDENPYO1);
                await _context.SaveChangesAsync();
                var listsum = from m in _context.ES_YDENPYOD
                              where m.DENPYONO == eS_YDENPYO.ES_YDENPYO1.DENPYONO
                              select m.KINGAKU;
                var sumss = listsum.Sum();
                Setsum(eS_YDENPYO.ES_YDENPYO1.DENPYONO, sumss);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ES_YDENPYOExists(eS_YDENPYO.ES_YDENPYO1.DENPYONO))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
            /* }*/
            return View("Create", C_ES_YDENPYO1);
        }

        // GET: ES_YDENPYO1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ES_YDENPYO == null)
            {
                return NotFound();
            }

            var eS_YDENPYO = await _context.ES_YDENPYO
                .FirstOrDefaultAsync(m => m.DENPYONO == id);
            if (eS_YDENPYO == null)
            {
                return NotFound();
            }

            return View(eS_YDENPYO);
        }

        // POST: ES_YDENPYO1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.ES_YDENPYO == null)
            {
                return Problem("Entity set 'First_ProjectContext.ES_YDENPYO'  is null.");
            }
            var CS_YDENPYO1 = await _context.ES_YDENPYO.FindAsync(id);
            var CS_YDENPYOD = await _context.ES_YDENPYOD.Where(m => m.DENPYONO == CS_YDENPYO1.DENPYONO).Select(m => m).ToListAsync();
            foreach (var esd in CS_YDENPYOD)
            {
                _context.ES_YDENPYOD.Remove(esd);
                await _context.SaveChangesAsync();
            }
            if (CS_YDENPYO1 != null && CS_YDENPYOD != null)
            {
                _context.ES_YDENPYO.Remove(CS_YDENPYO1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ES_YDENPYOExists(int id)
        {
            return (_context.ES_YDENPYO?.Any(e => e.DENPYONO == id)).GetValueOrDefault();
        }

        //GetName
        public async Task<IActionResult> GetName(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eS_YDENPYO =  _context.BUMON
                .Where(m => m.BUMONCD == id).Select(m => m.BUMONNM);//Contains chi tra ra chuoi 
            if (eS_YDENPYO == null)
            {
                return NotFound();
            }

            return Content(eS_YDENPYO.First());//Contains chi tra ra chuoi nen o day chi tra ra truong ten trong bang BUMON chu k tra ra 1 view
        }

        //Edit2
       [HttpPost]
        public async Task<IActionResult> Edit2(ES_YDENPYODViewModel eS_YDENPYOD)
        {

            var C_ES_YDENPYOD1 = new ES_YDENPYODViewModel
            {
                ES_YDENPYOD1 = eS_YDENPYOD.ES_YDENPYOD1,

            };

            Console.WriteLine(C_ES_YDENPYOD1.ES_YDENPYOD1.GYONO+"NNNNNNNNNNNNNNNNNNNNNNNNNNNNNN");
            /*  if (ModelState.IsValid)
              {*/
            
            _context.ES_YDENPYOD.Remove(eS_YDENPYOD.ES_YDENPYOD1);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
            /* }*/
            return View("Create", C_ES_YDENPYOD1);

        }

        public async void Setsum(int id, int ss)
        {
            Console.WriteLine(ss);
            Console.WriteLine(id);

            var es = await _context.ES_YDENPYO.FirstOrDefaultAsync(m => m.DENPYONO == id);
            es.KINGAKU = ss;
            _context.Update(es);
            await _context.SaveChangesAsync();
            
        }
    }
}
