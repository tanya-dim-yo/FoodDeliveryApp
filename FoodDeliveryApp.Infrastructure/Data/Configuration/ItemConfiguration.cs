using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        private Item[] initialItems = new Item[]
        {
            new Item()
            {
                Id = 1,
                Title = "Бургер Crispy Chicken (183г)",
                Description = "4\" питка, криспи чикън кюфте, майонеза, домати, айсберг",
                Price = 9.95m,
                IsFavourite = false,
                IsVeggie = false,
                ImageURL = "~/images/Amerikanska/BurgerKing/BurgerCrispyChicken.jpg",
                ItemCategoryId = 1,
                RestaurantId = 1,
                SpicyCategoryId = 1
            },

            new Item()
            {
                Id = 2,
                Title = "Бургер Tender Crisp (283г)",
                Description = "4 1/2\" питка, тендър крисп, майонеза, домати, айсберг",
                Price = 12.65m,
                IsFavourite = false,
                IsVeggie = false,
                ImageURL = "~/images/Amerikanska/BurgerKing/BurgerTenderCrisp.jpg",
                ItemCategoryId = 1,
                RestaurantId = 1,
                SpicyCategoryId = 1
            },

            new Item()
            {
                Id = 3,
                Title = "Салата Капрезе (300г)",
                Description = "пресни домати, босилек и сирене Моцарела",
                Price = 6.76m,
                IsFavourite = false,
                IsVeggie = false,
                ImageURL = "~/images/Mestna_hrana/Tarator/Salata_Kapreze.jpg",
                ItemCategoryId = 2,
                RestaurantId = 2,
                SpicyCategoryId = 1
            },

            new Item()
            {
                Id = 4,
                Title = "Мусака (350г)",
                Description = "Традиционна българска мусака",
                Price = 11.20m,
                IsFavourite = false,
                IsVeggie = false,
                ImageURL = "~/images/Mestna_hrana/Tarator/Musaka.jpg",
                ItemCategoryId = 3,
                RestaurantId = 2,
                SpicyCategoryId = 1
            },

            new Item()
            {
                Id = 5,
                Title = "Капучино Мока",
                Description = "Капучино с топка сладолед Mока",
                Price = 6.90m,
                IsFavourite = false,
                IsVeggie = false,
                ImageURL = "~/images/Zakuska/Mikel_Coffee/Cappuccino_Mocha.png",
                ItemCategoryId = 4,
                RestaurantId = 3,
                SpicyCategoryId = 1
            },

            new Item()
            {
                Id = 6,
                Title = "Бисквитена торта - Biscuit cake",
                Description = "Класическа бисквитена торта",
                Price = 7.40m,
                IsFavourite = false,
                IsVeggie = false,
                ImageURL = "~/images/Zakuska/Mikel_Coffee/Biscuit_Cake.png",
                ItemCategoryId = 5,
                RestaurantId = 3,
                SpicyCategoryId = 1
            },
        };

        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(initialItems);
        }
    }
}