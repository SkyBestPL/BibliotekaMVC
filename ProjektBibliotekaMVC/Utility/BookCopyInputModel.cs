using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ProjektBibliotekaMVC.Models;

namespace ProjektBibliotekaMVC.Utility
{
    public class BookCopyInputModel
    {
        [ValidateNever]
        public int IdBook { get; set; }
        [ValidateNever]
        public int IdBookCopy { get; set; }
        [ValidateNever]
        public string Status { get; set; }
        [ValidateNever]
        public string NewStatus { get; set; }
        [Range(0, 1000, ErrorMessage = "Ilosc powinna byc pomiedzy 0 a 1000")]
        [ValidateNever]
        public int Amount { get; set; }
        [ValidateNever]
        public int Deleted { get; set; }
    }
}
