using Microsoft.AspNetCore.Identity;
using System.Data;

namespace ProjektBibliotekaMVC.Models
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Role Role { get; set; }
    }
}
