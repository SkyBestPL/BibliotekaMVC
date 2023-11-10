using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektBibliotekaMVC.Data;
using ProjektBibliotekaMVC.Models;
using ProjektBibliotekaMVC.Utility;

namespace ProjektBibliotekaMVC.Controllers
{
    public class BookCopiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCopiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCopies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BooksCopies.Include(b => b.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexForBook(int id)
        {
            var applicationDbContext = _context.BooksCopies.Include(b => b.Book).Where(u => u.Id == id);
            ViewBag.Id = id;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookCopies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BooksCopies == null)
            {
                return NotFound();
            }

            var bookCopy = await _context.BooksCopies
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            return View(bookCopy);
        }

        // GET: BookCopies/Create
        public IActionResult Create(int id)
        {
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents");
            BookCopy bookCopy = new BookCopy();
            bookCopy.IdBook = id;
            //ViewBag.IdBook = id;
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            ViewBag.Title = book.Title;
            bookCopy.Book = book;
            return View(bookCopy);
        }

        // POST: BookCopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdBook,Status")] BookCopy bookCopy)
        {
            bookCopy.Status = SD.BookInMagazine;
            bookCopy.Id = 0;
            //if (ModelState.IsValid)
            if(ModelState.ErrorCount <= 2)
            {
                _context.Add(bookCopy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents", bookCopy.IdBook);
            return View(bookCopy);
        }

        // GET: BookCopies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BooksCopies == null)
            {
                return NotFound();
            }

            var bookCopy = await _context.BooksCopies.FindAsync(id);
            if (bookCopy == null)
            {
                return NotFound();
            }
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents", bookCopy.IdBook);
            return View(bookCopy);
        }

        // POST: BookCopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdBook,Status")] BookCopy bookCopy)
        {
            if (id != bookCopy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCopy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCopyExists(bookCopy.Id))
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
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents", bookCopy.IdBook);
            return View(bookCopy);
        }

        // GET: BookCopies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BooksCopies == null)
            {
                return NotFound();
            }

            var bookCopy = await _context.BooksCopies
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCopy == null)
            {
                return NotFound();
            }

            return View(bookCopy);
        }

        // POST: BookCopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BooksCopies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BooksCopies'  is null.");
            }
            var bookCopy = await _context.BooksCopies.FindAsync(id);
            if (bookCopy != null)
            {
                _context.BooksCopies.Remove(bookCopy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCopyExists(int id)
        {
          return (_context.BooksCopies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
