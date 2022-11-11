using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductOption>? ProductOptions { get; set; }
        public DbSet<ProductVariant>? ProductVariants { get; set; }
        public DbSet<Option>? Options { get; set; }
        public DbSet<OptionValue>? OptionValues { get; set; }
        public DbSet<VariantValue>? VariantValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Child>()
            //    .HasOne(p => p.Parents)
            //    .WithMany(c => c.Children)
            //    .HasForeignKey(c => c.ParentId);

            //modelBuilder.Entity<Child>()
            //    .Navigation(b => b.Parents)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);

            //modelBuilder.Entity<Products>()
            //    .HasOne(p => p.Children)
            //    .WithMany(c=>c.Parents)


        }
    }
}
