using ProjektBibliotekaMVC.Models;

namespace ProjektBibliotekaMVC.Utility
{
    public class BooksAndNews
    {
        public List<Book> Books { get; set; } = new();
        public List<News> News { get; set; } = new();
    }
}
