using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace ProjektBibliotekaMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public async Task<IActionResult> Cart()
        {
            var user = await _userManager.GetUserAsync(User);

            var cartItems = _context.Carts.Where(c => c.IdUser == user.Id).ToList();

            for (int i = cartItems.Count - 1; i >= 0; i--)
            {
                var c = cartItems[i];
                var bookCopies = _context.BooksCopies.Where(bc => bc.IdBook == c.IdBook && bc.Status == "InMagazine").ToList();
                if (bookCopies.Count == 0)
                {
                    cartItems.RemoveAt(i);
                    await RemoveFromCart(c.Id);
                    TempData["Message"] = "Usunięto jedną lub więcej książek, które nie są już dostępne.";
                }
            }
            return View(cartItems);
        }

        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);

            var cartItems = _context.Carts.Where(c => c.IdUser == user.Id).ToList();

            return View(cartItems);
        }

        public async Task<IActionResult> BorrowedBooks()
        {
            var user = await _userManager.GetUserAsync(User);

            var waitingBooks = _context.WaitingBook.Where(c => c.IdUser == user.Id).ToList();

            ViewBag.BorrowedBooks = _context.Borrows.Where(b => b.IdUser == user.Id).ToList();

            return View(waitingBooks);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(List<int> bookId)
        {

            var user = await _userManager.GetUserAsync(User);

            var books = _context.Books.ToList();
            int waitingTotal = 0;
            foreach (var b in books)
            {
                waitingTotal += b.WaitingCount;
            }
            int waitingLimit = _context.Limits.FirstOrDefault().WaitingLimit;
            if (waitingTotal + bookId.Count > waitingLimit) 
            {
                ViewBag.WaitingLimitExceeded = "Waiting limit exceeded!";
                return RedirectToAction(nameof(Checkout));
            }            

            foreach (var id in bookId)
            {
                var firstAvailableCopyId = _context.BooksCopies
                    .Where(bc => bc.IdBook == id && bc.Status == "InMagazine")
                    .OrderBy(bc => bc.Id)
                    .Select(bc => bc.Id)
                    .FirstOrDefault();

                if (firstAvailableCopyId != 0)
                {
                    var reservedCopy = _context.BooksCopies.Find(firstAvailableCopyId);
                    var reservedBook = _context.Books.Find(id);
                    reservedCopy.Status = "IsWaiting";
                    //reservedCopy.Book.InMagazineCount--;
                    //reservedCopy.Book.WaitingCount++;
                    reservedBook.InMagazineCount--;
                    reservedBook.WaitingCount++;
                    _context.SaveChanges();

                    var waitingBook = new WaitingBook
                    {
                        IdBookCopy = firstAvailableCopyId,
                        IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        Date = DateTime.Now,
                        BookCopy = reservedCopy, //tutaj przypisuję BookCopy ale później i tak jest null
                        User = user
                    };

                    _context.WaitingBook.Add(waitingBook);

                    reservedCopy.WaitingBook = waitingBook;

                    await _context.SaveChangesAsync();

                    var cartItem = await _context.Carts
                    .FirstOrDefaultAsync(ci => ci.IdBook == reservedCopy.IdBook && ci.IdUser == user.Id);

                    _context.Carts.Remove(cartItem);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Cart");
                }
                else
                {
                    return RedirectToAction("Cart");
                }
            }

            return RedirectToAction("Cart");
        }

        public CartController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound("Użytkownik nie został znaleziony.");
                }

                var cartItem = await _context.Carts.FindAsync(cartItemId);

                if (cartItem == null || cartItem.IdUser != user.Id)
                {
                    return NotFound("Nie znaleziono przedmiotu w koszyku.");
                }

                _context.Carts.Remove(cartItem);

                await _context.SaveChangesAsync();

                return RedirectToAction("Cart");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
