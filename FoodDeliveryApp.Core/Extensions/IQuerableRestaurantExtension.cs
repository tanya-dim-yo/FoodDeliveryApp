using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace System.Linq
{
	public static class IQuerableRestaurantExtension
	{
		public static IQueryable<RestaurantViewModel> ProjectToRestaurantViewModel(this IQueryable<Restaurant> restaurants)
		{
			return restaurants
				.Select(r => new RestaurantViewModel
				{
					Id = r.Id,
					Title = r.Title,
					ServiceFee = r.ServiceFee,
					MinDeliveryTimeInMinutes = r.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = r.MaxDeliveryTimeInMinutes,
					ImageURL = r.ImageURL,
					RestaurantCategory = r.RestaurantCategory.Title
				});
		}
	}
}
