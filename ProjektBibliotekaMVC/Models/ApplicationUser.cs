using Microsoft.AspNetCore.Identity;

namespace ProjektBibliotekaMVC.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public List<BorrowHistory> BorrowsHistory { get; } = new();
        public List<Queue> Queues { get; } = new();
        public List<Borrow> Borrows { get; } = new();
        public List<Cart> Carts { get; } = new();
        public List<SearchHistory> SearchesHistory { get; } = new();
    }
}
