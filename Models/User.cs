using Microsoft.AspNetCore.Identity;

namespace security_system.Models
{
    public class User : IdentityUser<int>
    {

        public virtual ICollection<UserRole> UserRoles { get; set; } = [];
    }
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; } = null!;
        public AppRole Role { get; set; } = null!;
    }
    public class AppRole : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}

