using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class Limit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int InMagazineLimit { get; set; }
        [Required]
        public int WaitingLimit { get; set; }
    }
}