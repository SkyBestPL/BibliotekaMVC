using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            return View(cartItems);
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
