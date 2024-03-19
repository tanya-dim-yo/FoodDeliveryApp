using FoodDeliveryApp.Core.Contracts.Restaurant;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Core.Services.Restaurant
{
	public class RestaurantService : IRestaurantService
	{
		private readonly IRepository repository;

        public RestaurantService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task AddAsync(RestaurantDetailViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task EditAsync(RestaurantDetailViewModel model)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<RestaurantViewModel>> GetAllAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Select(p => new RestaurantViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					DeliveryTime = p.DeliveryTime,
					BackgroundImage = p.BackgroundImage,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.ToListAsync();
		}

		public Task<RestaurantDetailViewModel?> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task RateRestaurant(int restaurantId, double newRating)
		{
			var restaurant = await repository.All<Infrastructure.Data.Models.Restaurant>()
				.FirstOrDefaultAsync(r => r.Id == restaurantId);

			if (restaurant == null)
			{
				throw new Exception("Restaurant not found.");
			}

			restaurant.UpdateRating(newRating);

			await repository.SaveChangesAsync();
		}
	}
}