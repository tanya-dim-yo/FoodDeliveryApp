using FoodDeliveryApp.Core.Contracts.Restaurant;
using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryApp.Core.Services.Restaurant
{
	public class RestaurantService : IRestaurantService
	{
		private readonly IRepository repository;
		private readonly ILogger logger;

		public RestaurantService(
			IRepository _repository,
			ILogger<RestaurantService> _logger)
        {
            repository = _repository;
			logger = _logger;
		}

        public Task AddAsync(RestaurantDetailViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task EditAsync(RestaurantDetailViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(RestaurantDetailViewModel model)
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

		public async Task<IEnumerable<RestaurantViewModel>> GetByCategoryAsync(int categoryId)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(p => p.RestaurantCategoryId == categoryId)
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

		public async Task<IEnumerable<RestaurantViewModel>> HighestRatingAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.OrderByDescending(p => p.AverageRating)
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

		public async Task<IEnumerable<ItemViewModel>> MenuAsync(int restaurantId)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Item>()
				.Where(i => i.RestaurantId == restaurantId)
				.Select(i => new ItemViewModel()
				{
					Id = i.Id,
					Title = i.Title,
					Description = i.Description,
					Price = i.Price,
					Image = i.Image,
					ItemCategory = i.ItemCategory.Title,
					AverageRating = i.AverageRating,
					TotalReviews = i.TotalReviews
				})
				.ToListAsync();
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

        public async Task<IEnumerable<RestaurantViewModel>> SearchAsync(string keyword)
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Restaurant>()
                .Where(p => p.Title.Contains(keyword)
					|| p.Items.Any(i => i.Title.Contains(keyword)
					|| i.Description.Contains(keyword)))
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

        public async Task<IEnumerable<RestaurantViewModel>> ServiceFeeAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.OrderBy(p => p.ServiceFee)
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

		public async Task<RestaurantViewModel?> GetByIdAsync(int id)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(p => p.Id == id)
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
				.FirstOrDefaultAsync();
		}


	}
}