using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
    public class RestaurantCategoryConfiguration : IEntityTypeConfiguration<RestaurantCategory>
    {
        private RestaurantCategory[] initialRestaurantCategories = new RestaurantCategory[]
        {
            new RestaurantCategory() { Id = 1, Title = "Азиатска" },
            new RestaurantCategory() { Id = 2, Title = "Американска" },
            new RestaurantCategory() { Id = 3, Title = "Арабска" },
            new RestaurantCategory() { Id = 4, Title = "Вегетарианска" },
            new RestaurantCategory() { Id = 5, Title = "Гръцка" },
            new RestaurantCategory() { Id = 6, Title = "Десерти" },
            new RestaurantCategory() { Id = 7, Title = "Закуска" },
            new RestaurantCategory() { Id = 8, Title = "Здравословна" },
            new RestaurantCategory() { Id = 9, Title = "Индийска" },
            new RestaurantCategory() { Id = 10, Title = "Италианска" },
            new RestaurantCategory() { Id = 11, Title = "Международна" },
            new RestaurantCategory() { Id = 12, Title = "Мексиканска" },
            new RestaurantCategory() { Id = 13, Title = "Местна храна" },
            new RestaurantCategory() { Id = 14, Title = "Морски дарове" },
            new RestaurantCategory() { Id = 15, Title = "Напитки" },
            new RestaurantCategory() { Id = 16, Title = "Паста" },
            new RestaurantCategory() { Id = 17, Title = "Печива и сладкиши" },
            new RestaurantCategory() { Id = 18, Title = "Сандвич" },
            new RestaurantCategory() { Id = 19, Title = "Средиземноморска" },
            new RestaurantCategory() { Id = 20, Title = "Суши" },
            new RestaurantCategory() { Id = 21, Title = "Турска" },
            new RestaurantCategory() { Id = 22, Title = "Чай и кафе" }
        };

        public void Configure(EntityTypeBuilder<RestaurantCategory> builder)
        {
            builder.HasData(initialRestaurantCategories);
        }
    }
}