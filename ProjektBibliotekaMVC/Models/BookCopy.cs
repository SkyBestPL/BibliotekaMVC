using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProjektBibliotekaMVC.Models
{
    public class BookCopy
    {
        [Key]
        public int Id { get; set; }
        public int IdBook { get; set; }
        [Required]
        public string Status { get; set; }
        public Book Book { get; set; }
        public Borrow? Borrow { get; set; }
        public WaitingBook? WaitingBook { get; set; }
    }
}