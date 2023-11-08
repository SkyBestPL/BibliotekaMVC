﻿using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
    }
}