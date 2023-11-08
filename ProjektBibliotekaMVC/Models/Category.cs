using System.ComponentModel.DataAnnotations;

namespace ProjektBibliotekaMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category> ChildCategories { get; } = new();
    }
}