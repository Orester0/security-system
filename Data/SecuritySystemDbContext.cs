using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using security_system.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace security_system.Data
{
    public class SecuritySystemDbContext(DbContextOptions options) : IdentityDbContext<User, AppRole, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
    {
    }
}
