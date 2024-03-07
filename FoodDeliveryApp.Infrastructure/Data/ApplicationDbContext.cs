using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AddOn>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<CartItem>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<Coupon>()
                .Property(c => c.Discount)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<Item>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<Order>()
                .Property(o => o.SubTotal)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                .Property(o => o.ServiceFee)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                .Property(o => o.Tax)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                .Property(o => o.OrderTotal)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Payment>()
                .Property(p => p.PaymentTotal)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
        }
    }
}