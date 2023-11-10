using Microsoft.AspNetCore.Identity;

namespace ProjektBibliotekaMVC.Models
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
