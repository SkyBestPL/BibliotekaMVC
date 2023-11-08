using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
