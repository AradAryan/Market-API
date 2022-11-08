using Market.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Market.Presentation
{

    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder) =>
        //optionsBuilder.UseSqlServer("Server=.;Database=MarketIdentity;Trusted_Connection=True;MultipleActiveResultSets=true");
        //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MarketIdentity;Trusted_Connection=True;MultipleActiveResultSets=true");
        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sarzamin Hoshmand.DESKTOP-A9E5A8H\\Documents\\DB.mdf\";Integrated Security=True;Connect Timeout=30");
    }
}
