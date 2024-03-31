using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
    internal class ItemAddOnConfiguration : IEntityTypeConfiguration<ItemAddOn>
    {
        public void Configure(EntityTypeBuilder<ItemAddOn> builder)
        {
            builder.HasKey(ia => new { ia.ItemId, ia.AddOnId });

            builder.HasOne(i => i.Item)
                .WithMany(i => i.ItemsAddOns)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}