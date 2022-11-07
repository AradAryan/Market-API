using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.Presentation
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder) =>
                optionsBuilder.UseSqlServer("Server=.;Database=MarketIdentity;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
