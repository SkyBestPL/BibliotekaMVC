﻿using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class SearchHistory
    {
        [Key]
        public int Id { get; set; }
        public int IdBook { get; set; }
        public string IdUser { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
    }
}