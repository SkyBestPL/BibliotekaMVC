using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class BookCopy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        public Book Book { get; set; }
        public Borrow? Borrow { get; set; }
    }
}