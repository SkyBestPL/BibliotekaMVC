using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public BookCopy BookCopy { get; set; }
        public ApplicationUser User { get; set; }
    }
}