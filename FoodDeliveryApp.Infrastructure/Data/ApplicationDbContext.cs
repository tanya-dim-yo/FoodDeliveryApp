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
            builder.Entity<ItemAddOn>()
                .HasKey(ia => new { ia.ItemId, ia.AddOnId });

            builder.Entity<ItemAddOn>()
                .HasOne(ia => ia.AddOn)
                .WithMany()
                .HasForeignKey(ia => ia.AddOnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ItemAddOn>()
                .HasOne(ia => ia.Item)
                .WithMany()
                .HasForeignKey(ia => ia.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

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

        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<BlogArticle> BlogArticles { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemAddOn> ItemsAddOns { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemReview> ItemReviews { get; set; }
        public DbSet<ItemSpicyCategory> ItemSpicyCategories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
    }
}