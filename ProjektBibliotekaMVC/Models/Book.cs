using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjektBibliotekaMVC.Models;

namespace ProjektBibliotekaMVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurename { get; set; }
        public int IdCategory { get; set; }
        [Required]
        public int ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Contents { get; set; }
        public int InMagazineCount { get; set; } = 0;
        public int WaitingCount { get; set; } = 0;
        public int BorrowedCount { get; set; } = 0;
        public List<Tag> Tags { get; } = new();
        public List<BorrowHistory> BorrowsHistory { get; } = new();
        public List<BookCopy> BookCopies { get; } = new();
        public List<Queue> Queues { get; } = new();
        public List<Cart> Carts { get; } = new();
        public List<SearchHistory> SearchesHistory { get; } = new();
    }
}