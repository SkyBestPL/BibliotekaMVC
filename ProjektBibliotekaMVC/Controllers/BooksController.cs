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

namespace BibliotekaMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Index()
        {
              return _context.Books != null ? 
                          View(await _context.Books.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Books'  is null.");
        }

        public async Task<IActionResult> BooksList()
        {
            return _context.Books != null ?
                        View(await _context.Books.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Books'  is null.");
        }

        // GET: Books/Details/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var bookEntity = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return View(bookEntity);
        }

        // GET: Books/Create
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Create([Bind("Id,AuthorName,AuthorSurename,IdCategory,ISBN,Title,Contents")] Book bookEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookEntity);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var bookEntity = await _context.Books.FindAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }
            return View(bookEntity);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAuthor,IdCathegory,ISBN,Title,Contents,Status")] Book bookEntity)
        {
            if (id != bookEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookEntityExists(bookEntity.Id))
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
            return View(bookEntity);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var bookEntity = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return View(bookEntity);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
            }
            var bookEntity = await _context.Books.FindAsync(id);
            if (bookEntity != null)
            {
                _context.Books.Remove(bookEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookEntityExists(int id)
        {
          return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public IActionResult ViewCopies(int id)
        {
            return RedirectToAction("IndexForBook", new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = id }));
        }
    }
}
