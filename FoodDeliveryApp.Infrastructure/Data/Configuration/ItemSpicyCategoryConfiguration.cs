using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
    public class ItemSpicyCategoryConfiguration : IEntityTypeConfiguration<ItemSpicyCategory>
    {
        private ItemSpicyCategory[] initialItemSpicyCategories = new ItemSpicyCategory[]
        {
            new ItemSpicyCategory() { Id = 1, Title = "Не лютиво" },
            new ItemSpicyCategory() { Id = 2, Title = "Леко лютиво" },
            new ItemSpicyCategory() { Id = 3, Title = "Средно лютиво" },
            new ItemSpicyCategory() { Id = 4, Title = "Много лютиво" }
        };

        public void Configure(EntityTypeBuilder<ItemSpicyCategory> builder)
        {
            builder.HasData(initialItemSpicyCategories);
        }
    }
}