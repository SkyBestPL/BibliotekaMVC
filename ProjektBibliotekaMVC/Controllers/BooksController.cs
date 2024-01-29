using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
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

        public async Task<IActionResult> ManageTags(int? id)
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

            var book = await _context.Books
                .Include(b => b.Tags)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var allTags = await _context.Tags.ToListAsync();

            var bookTags = book.Tags.ToList();

            var unassignedTags = allTags.Except(bookTags).ToList();

            ViewBag.AllTags = unassignedTags;

            return View("ManageTags", bookEntity);
        }

        public async Task<IActionResult> BooksList(string searchString)
        {
            var books = _context.Books.ToList();
            var user = await _userManager.GetUserAsync(User);
            if(user != null)
            {
                ViewBag.UserId = user.Id;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => 
                b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                (b.AuthorName + " " + b.AuthorSurename).Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                b.ISBN.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(books);

            /*return _context.Books != null ?
                        View(await _context.Books.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Books'  is null.");*/
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
        public async Task<IActionResult> Create([Bind("Id,AuthorName,AuthorSurename,IdCategory,ISBN,Title,Contents, InMagazineCount")] Book bookEntity)
        {
            var books = _context.Books.ToList();
            int magazineTotal = 0;
            foreach (var b in books)
            {
                magazineTotal += b.InMagazineCount;
            }
            int magazineLimit = _context.Limits.FirstOrDefault().InMagazineLimit;
            if (magazineTotal + bookEntity.InMagazineCount > magazineLimit)
                ModelState.AddModelError("Limit", "Magazine limit exceeded!");

            if (ModelState.IsValid)
            {
                _context.Add(bookEntity);
                
                //tworzenie rekordów w BookCopies na podstawie InMagazineCount
                for (int i = 0; i < bookEntity.InMagazineCount; i++)
                {
                    var bookCopy = new BookCopy
                    {
                        IdBook = bookEntity.Id,
                        Status = "InMagazine",
                        Book = bookEntity,
                    };

                    bookEntity.BookCopies.Add(bookCopy);
                }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAuthor,IdCathegory,ISBN,Title,Contents,InMagazineCount")] Book bookEntity)
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

        [HttpPost]
        public async Task<IActionResult> AddToCart(int bookId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return Redirect("/Identity/Account/Login");
                }

                var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

                if (book == null)
                {
                    return NotFound("Książka nie została znaleziona.");
                }

                var newCart = new Cart
                {
                    IdBook = book.Id,
                    IdUser = user.Id,
                    Book = book,
                    User = user,
                };

                _context.Carts.Add(newCart);

                await _context.SaveChangesAsync();

                return RedirectToAction("BooksList");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToQueue(int bookId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return Redirect("/Identity/Account/Login");
                }

                var book = _context.Books.FirstOrDefault(b => b.Id == bookId);

                if (book == null)
                {
                    return NotFound("Książka nie została znaleziona.");
                }


                var existingQueueItem = _context.Queues
                    .FirstOrDefault(q => q.IdBook == bookId && q.IdUser == user.Id);

                if (existingQueueItem == null)
                {
                    var queueItem = new Queue
                    {
                        IdBook = bookId,
                        IdUser = user.Id,
                        Date = DateTime.Now,
                        Book = book,
                        User = user
                    };

                    _context.Queues.Add(queueItem);
                    _context.SaveChanges();

                    return RedirectToAction("BooksList");
                }
                else
                {
                    return Json(new { success = false, message = "Użytkownik już jest w kolejce dla tej książki." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
