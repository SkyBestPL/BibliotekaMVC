using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class BorrowHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
    }
}
