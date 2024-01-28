using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBibliotekaMVC.Data;
using ProjektBibliotekaMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjektBibliotekaMVC.Controllers
{
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TagsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddTagToBook(int bookId, string tagName)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
            if (tag == null)
            {
                tag = new Tag { Name = tagName };
                _context.Tags.Add(tag);
            }

            var book = await _context.Books.Include(b => b.Tags).FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                return NotFound();
            }

            if (!book.Tags.Any(t => t.Id == tag.Id))
            {
                book.Tags.Add(tag);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Books");
        }
    }
}
