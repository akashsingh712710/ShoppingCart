using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 

namespace Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.MRP)
                    .HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShippingMethod>().HasData(
            new ShippingMethod { Id = 1, MethodName = "Standard Shipping", Cost = 5.99m },
            new ShippingMethod { Id = 2, MethodName = "Express Shipping", Cost = 9.99m },
            new ShippingMethod { Id = 3, MethodName = "Next Day Shipping", Cost = 19.99m }
        );
        }
    }
}
