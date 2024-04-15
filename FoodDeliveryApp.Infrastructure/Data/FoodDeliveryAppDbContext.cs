using FoodDeliveryApp.Infrastructure.Data.Configuration;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Infrastructure.Data
{
    public class FoodDeliveryAppDbContext : IdentityDbContext
    {
        public FoodDeliveryAppDbContext(DbContextOptions<FoodDeliveryAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.ApplyConfiguration(new IdentityUserConfiguration());
			builder.ApplyConfiguration(new ItemAddOnConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new RestaurantCategoryConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new ItemSpicyCategoryConfiguration());
            builder.ApplyConfiguration(new ItemCategoryConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
			builder.ApplyConfiguration(new CityConfiguration());

			base.OnModelCreating(builder);
        }

        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<BlogArticle> BlogArticles { get; set; }
        public DbSet<BlogArticleCategory> BlogArticleCategories { get; set; }
        public DbSet<BlogArticleComment> BlogArticleComments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
		public DbSet<City> Cities { get; set; }
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