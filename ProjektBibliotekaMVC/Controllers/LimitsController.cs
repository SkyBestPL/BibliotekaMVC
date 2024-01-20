using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektBibliotekaMVC.Data;
using ProjektBibliotekaMVC.Models;

namespace ProjektBibliotekaMVC.Controllers
{
    public class LimitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LimitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Limits
        public async Task<IActionResult> Index()
        {
              return _context.Limits != null ? 
                          View(await _context.Limits.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Limits'  is null.");
        }

        // GET: Limits/Details/5
        public async Task<IActionResult> Details()
        {
            var books = _context.Books.ToList();
            int magazineTotal = 0, waitingTotal = 0;
            foreach(var b in books)
            {
                magazineTotal += b.InMagazineCount;
                waitingTotal+= b.WaitingCount;
            }
            ViewBag.MagazineTotal = magazineTotal;
            ViewBag.WaitingTotal = waitingTotal;

            var limit = await _context.Limits.FirstOrDefaultAsync();
            

            return View(limit);
        }

        // GET: Limits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Limits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InMagazineLimit,WaitingLimit")] Limit limit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(limit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(limit);
        }

        // GET: Limits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Limits == null)
            {
                return NotFound();
            }

            var limit = await _context.Limits.FindAsync(id);
            if (limit == null)
            {
                return NotFound();
            }
            return View(limit);
        }

        // POST: Limits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InMagazineLimit,WaitingLimit")] Limit limit)
        {
            if (id != limit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(limit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LimitExists(limit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            return View(limit);
        }

        // GET: Limits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Limits == null)
            {
                return NotFound();
            }

            var limit = await _context.Limits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (limit == null)
            {
                return NotFound();
            }

            return View(limit);
        }

        // POST: Limits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Limits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Limits'  is null.");
            }
            var limit = await _context.Limits.FindAsync(id);
            if (limit != null)
            {
                _context.Limits.Remove(limit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LimitExists(int id)
        {
          return (_context.Limits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
