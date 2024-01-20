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

namespace BibliotekaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var booksTempTemp = await _context.Books.ToListAsync();
            var booksTemp = booksTempTemp.OrderByDescending(u => u.Id);
            List<Book> books = new List<Book>();
            int i = 0;
            foreach(var bookTemp in booksTemp)
            {
                if (i < 5) 
                    books.Add(bookTemp);
                i++;
            }
            List<News> news = _context.Newses.ToList();
            BooksAndNews booksAndNews = new BooksAndNews();
            booksAndNews.Books = books;
            booksAndNews.News = news;
            return View(booksAndNews);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}