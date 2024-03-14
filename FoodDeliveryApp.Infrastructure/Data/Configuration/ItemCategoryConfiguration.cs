using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        private ItemCategory[] initialItemCategories = new ItemCategory[]
        {
            new ItemCategory() { Id = 1, Title = "Пилешки бургери" },
            new ItemCategory() { Id = 2, Title = "Салати" },
            new ItemCategory() { Id = 3, Title = "Основни" },
            new ItemCategory() { Id = 4, Title = "Горещи напитки" },
            new ItemCategory() { Id = 5, Title = "Десерти" },
        };

        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.HasData(initialItemCategories);
        }
    }
}