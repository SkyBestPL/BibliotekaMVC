using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class BorrowHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdBook { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookISBN { get; set; }
        public string IdUser { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ApplicationUser User { get; set; }
    }
}
