using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektBibliotekaMVC.Data;
using ProjektBibliotekaMVC.Models;
using ProjektBibliotekaMVC.Utility;

namespace ProjektBibliotekaMVC.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;

        public BorrowsController(ApplicationDbContext context, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager= userManager;
        }

        // GET: Borrows
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Borrows.Include(b => b.BookCopy).ThenInclude(b => b.Book).Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Borrows/Details/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Borrows == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.BookCopy)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public IActionResult Create()
        {
            ViewData["IdBookCopy"] = new SelectList(_context.BooksCopies, "Id", "Status");
            ViewData["IdUser"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Create([Bind("Id,IdBookCopy,IdUser,Date")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBookCopy"] = new SelectList(_context.BooksCopies, "Id", "Status", borrow.IdBookCopy);
            ViewData["IdUser"] = new SelectList(_context.ApplicationUsers, "Id", "Id", borrow.IdUser);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Borrows == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["IdBookCopy"] = new SelectList(_context.BooksCopies, "Id", "Status", borrow.IdBookCopy);
            ViewData["IdUser"] = new SelectList(_context.ApplicationUsers, "Id", "Id", borrow.IdUser);
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdBookCopy,IdUser,Date")] Borrow borrow)
        {
            if (id != borrow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.Id))
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
            ViewData["IdBookCopy"] = new SelectList(_context.BooksCopies, "Id", "Status", borrow.IdBookCopy);
            ViewData["IdUser"] = new SelectList(_context.ApplicationUsers, "Id", "Id", borrow.IdUser);
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Borrows == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.BookCopy)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Borrows == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Borrows'  is null.");
            }
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow != null)
            {
                _context.Borrows.Remove(borrow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        private bool BorrowExists(int id)
        {
          return (_context.Borrows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
