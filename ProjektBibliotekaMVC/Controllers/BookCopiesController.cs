using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = SD.RoleUserAdmin+","+SD.RoleUserEmployee )]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BooksCopies.Include(b => b.Book);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> IndexForBook(int id)
        {
            var applicationDbContext = _context.BooksCopies.Include(b => b.Book).Where(u => u.IdBook == id);
            ViewBag.Id = id;
            Book book = await _context.Books.FindAsync(id);
            ViewBag.BookTitle = book.Title;
            ViewBag.InMagazineCount = book.InMagazineCount;
            ViewBag.WaitingCount = book.WaitingCount;
            ViewBag.BorrowedCount = book.BorrowedCount;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookCopies/Details/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
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
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public IActionResult Create(int id)
        {
            //ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents");
            //BookCopy bookCopy = new BookCopy();
            //bookCopy.IdBook = id;
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            ViewBag.BookTitle = book.Title;
            //bookCopy.Book = book;
            //bookCopy.Status = SD.BookInMagazine;
            var BookCopyAmount = new BookCopyInputModel();
            BookCopyAmount.IdBook = id;
            BookCopyAmount.Status = SD.BookInMagazine;
            BookCopyAmount.Amount = 1;
            return View(BookCopyAmount);
        }

        // POST: BookCopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Create([Bind("IdBook,Status,Amount")] BookCopyInputModel bookCopyAmount)
        {
            BookCopy bookCopy = new BookCopy();
            bookCopy.Status = bookCopyAmount.Status;
            bookCopy.IdBook = bookCopyAmount.IdBook;
            bookCopy.Id = 0;
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookCopyAmount.IdBook);
            if (ModelState.IsValid)
            {
                for (int i = 0; i < bookCopyAmount.Amount; i++)
                {
                    bookCopy = new BookCopy();
                    bookCopy.Status = bookCopyAmount.Status;
                    bookCopy.IdBook = bookCopyAmount.IdBook;
                    bookCopy.Id = 0;
                    _context.Add(bookCopy);
                    book.InMagazineCount++;
                    _context.Update(book);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexForBook), new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = bookCopyAmount.IdBook }));
            }
            //ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents", bookCopy.IdBook);
            return View(bookCopyAmount);
        }

        // GET: BookCopies/Edit/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
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
            var bookCopyAmount = new BookCopyInputModel();
            bookCopyAmount.Status = bookCopy.Status;
            bookCopyAmount.IdBookCopy = bookCopy.Id;
            bookCopyAmount.IdBook = bookCopy.IdBook;
            //ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents", bookCopy.IdBook);
            return View(bookCopyAmount);
        }

        // POST: BookCopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> Edit(int id, [Bind("IdBookCopy,IdBook,Status,NewStatus,Email")] BookCopyInputModel bookCopyAmount)
        {
            var bookCopy = _context.BooksCopies.FirstOrDefault(b => b.Id == bookCopyAmount.IdBookCopy);
            if (id != bookCopy.Id)
            {
                return NotFound();
            }
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookCopy.IdBook);
            if (ModelState.ErrorCount <= 1)
            {
                try
                {
                    var user = _context.Users.FirstOrDefault(u => u.Email == (string)bookCopyAmount.Email);
                    if (bookCopyAmount.Status != bookCopyAmount.NewStatus)
                    {
                        if (bookCopyAmount.NewStatus == SD.BookInMagazine)
                        {
                            book.InMagazineCount++;
                        }
                        else if (bookCopyAmount.NewStatus == SD.BookIsWaiting)
                        {
                            if (user == null)
                                return RedirectToAction(nameof(Edit), new RouteValueDictionary(new { controller = "BookCopies", action = "Edit", id = bookCopy.Id }));
                            var waitingBook = new WaitingBook();
                            waitingBook.IdUser = user.Id;
                            waitingBook.IdBookCopy = bookCopy.Id;
                            waitingBook.Date = DateTime.Now;
                            _context.Add(waitingBook);
                            book.WaitingCount++;
                        }
                        else if (bookCopyAmount.NewStatus == SD.BookIsBorrowed)
                        {
                            if (user == null)
                                return RedirectToAction(nameof(Edit), new RouteValueDictionary(new { controller = "BookCopies", action = "Edit", id = bookCopy.Id }));
                            var borrow = new Borrow();
                            borrow.IdUser = user.Id;
                            borrow.IdBookCopy = bookCopy.Id;
                            borrow.Date = DateTime.Now;
                            _context.Add(borrow);
                            book.BorrowedCount++;
                        }

                        if (bookCopyAmount.Status == SD.BookInMagazine)
                        {
                            book.InMagazineCount--;
                        }
                        else if (bookCopyAmount.Status == SD.BookIsWaiting)
                        {
                            if (user == null)
                                return RedirectToAction(nameof(Edit), new RouteValueDictionary(new { controller = "BookCopies", action = "Edit", id = bookCopy.Id }));
                            var waitingBook = _context.WaitingBook.FirstOrDefault(u => u.IdBookCopy == bookCopy.Id);
                            _context.Remove(waitingBook);
                            book.WaitingCount--;
                        }
                        else if (bookCopyAmount.Status == SD.BookIsBorrowed)
                        {
                            if (user == null)
                                return RedirectToAction(nameof(Edit), new RouteValueDictionary(new { controller = "BookCopies", action = "Edit", id = bookCopy.Id }));
                            var borrow = _context.Borrows.FirstOrDefault(u => u.IdBookCopy == bookCopy.Id);
                            _context.Remove(borrow);
                            book.BorrowedCount--;
                        }
                    }
                    bookCopy.Status = bookCopyAmount.NewStatus;
                    _context.Update(bookCopy);
                    _context.Update(book);
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
                return RedirectToAction(nameof(IndexForBook), new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = bookCopy.IdBook }));
            }
            //ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Contents", bookCopy.IdBook);
            return View(bookCopy);
        }

        // GET: BookCopies/Delete/5
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
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
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BooksCopies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BooksCopies'  is null.");
            }
            var bookCopy = _context.BooksCopies.Where(u => u.Id == id).FirstOrDefault();
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookCopy.IdBook);
            if (bookCopy != null)
            {
                
                if (bookCopy.Status == SD.BookInMagazine)
                {
                    book.InMagazineCount--;
                }
                else if (bookCopy.Status == SD.BookIsWaiting)
                {
                    var waitingBook = _context.WaitingBook.FirstOrDefault(u => u.IdBookCopy == bookCopy.Id);
                    if (waitingBook != null)
                    {
                        _context.Remove(waitingBook);
                        book.WaitingCount--;
                    }    
                }
                else if (bookCopy.Status == SD.BookIsBorrowed)
                {
                    var borrow = _context.Borrows.FirstOrDefault(u => u.IdBookCopy == bookCopy.Id);
                    if (borrow != null)
                    {
                        _context.Remove(borrow);
                        book.BorrowedCount--;
                    }
                }
                _context.Update(book);
                _context.BooksCopies.Remove(bookCopy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexForBook), new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = book.Id }));
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> MassDelete(int? id)
        {
            if (id == null || _context.BooksCopies == null)
            {
                return NotFound();
            }
            var BookCopyAmount = new BookCopyInputModel();
            BookCopyAmount.IdBook = (int)id;
            var book = await _context.Books.FindAsync(id);
            ViewBag.BookTitle = book.Title;
            return View(BookCopyAmount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> MassDelete([Bind("IdBook,Amount")] BookCopyInputModel bookCopyAmount)
        {
            if (_context.BooksCopies == null)
            {
                return RedirectToAction(nameof(IndexForBook), new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = bookCopyAmount.IdBook }));
                //return Problem("Entity set 'ApplicationDbContext.BooksCopies'  is null.");
            }
            if (_context.BooksCopies.Where(b => b.IdBook == bookCopyAmount.IdBook).Count() == 0)
            {
                return RedirectToAction(nameof(IndexForBook), new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = bookCopyAmount.IdBook }));
            }
            var bookCopies = _context.BooksCopies.Where(u => u.IdBook == bookCopyAmount.IdBook);
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookCopies.First().IdBook);
            int deleted = 1;
            foreach (var bookCopy in bookCopies)
            {
                if (deleted <= bookCopyAmount.Amount && bookCopy.Status == SD.BookInMagazine)
                {
                    _context.BooksCopies.Remove(bookCopy);
                    book.InMagazineCount--;
                    deleted++;
                }
            }
            _context.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexForBook), new RouteValueDictionary(new { controller = "BookCopies", action = "IndexForBook", id = bookCopyAmount.IdBook }));
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        private bool BookCopyExists(int id)
        {
          return (_context.BooksCopies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
