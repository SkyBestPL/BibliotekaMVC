using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektBibliotekaMVC.Data;
using ProjektBibliotekaMVC.Models;
using ProjektBibliotekaMVC.Utility;

namespace ProjektBibliotekaMVC.Controllers
{
    public class WaitingBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaitingBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WaitingBooks
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Index()
        {
              return _context.WaitingBook != null ? 
                          View(await _context.WaitingBook.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.WaitingBook'  is null.");
        }

        // GET: WaitingBooks/Details/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WaitingBook == null)
            {
                return NotFound();
            }

            var waitingBook = await _context.WaitingBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waitingBook == null)
            {
                return NotFound();
            }

            return View(waitingBook);
        }

        // GET: WaitingBooks/Create
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaitingBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Create([Bind("Id,IdBookCopy,IdUser,Date")] WaitingBook waitingBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waitingBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waitingBook);
        }

        // GET: WaitingBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WaitingBook == null)
            {
                return NotFound();
            }

            var waitingBook = await _context.WaitingBook.FindAsync(id);
            if (waitingBook == null)
            {
                return NotFound();
            }
            return View(waitingBook);
        }

        // POST: WaitingBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdBookCopy,IdUser,Date")] WaitingBook waitingBook)
        {
            if (id != waitingBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waitingBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaitingBookExists(waitingBook.Id))
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
            return View(waitingBook);
        }

        // GET: WaitingBooks/Delete/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WaitingBook == null)
            {
                return NotFound();
            }

            var waitingBook = await _context.WaitingBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waitingBook == null)
            {
                return NotFound();
            }

            return View(waitingBook);
        }

        // POST: WaitingBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WaitingBook == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WaitingBook'  is null.");
            }
            var waitingBook = await _context.WaitingBook.FindAsync(id);
            if (waitingBook != null)
            {
                _context.WaitingBook.Remove(waitingBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        private bool WaitingBookExists(int id)
        {
          return (_context.WaitingBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
