using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Domain
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<CategoryOption>? CategoryOptions { get; set; }
        public DbSet<CategoryOptionValue>? CategoryOptionValues { get; set; }
        public DbSet<Factor>? Factors { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<Option>? Options { get; set; }
        public DbSet<OptionValue>? OptionValues { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<PaymentTransaction>? PaymentTransactions { get; set; }
        public DbSet<Price>? Prices { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductOption>? ProductOptions { get; set; }
        public DbSet<ProductOptionValue>? ProductOptionValues { get; set; }
        public DbSet<ProductPrice>? ProductPrices { get; set; }
        public DbSet<Shop>? Shops { get; set; }
        public DbSet<ShopProductOptionValue>? ShopProductOptionValues { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<UsersAddress>? UsersAddresses { get; set; }
        public DbSet<VariantValue>? VariantValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}



