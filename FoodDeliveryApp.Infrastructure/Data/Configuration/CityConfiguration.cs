using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		private City[] initialCities = new City[]
	    {
			new City() { Id = 1, Name = "София" },
			new City() { Id = 2, Name = "Пловдив" },
			new City() { Id = 3, Name = "Варна" }
	    };

		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasData(initialCities);
		}
	}
}