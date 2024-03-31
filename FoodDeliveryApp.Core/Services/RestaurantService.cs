using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text.RegularExpressions;

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

		public async Task<int> AddRestaurantAsync(RestaurantFormModel model, DateTime openHour, DateTime closeHour)
		{
			var restaurant = new Infrastructure.Data.Models.Restaurant()
			{
				Title = model.Title,
				Address = model.Address,
				CityId = model.CityId,
				OpeningHour = openHour,
				ClosingHour = closeHour,
				Latitude = model.Latitude,
				Longitude = model.Longitude,
				ServiceFee = model.ServiceFee,
				MinDeliveryTimeInMinutes = model.MinDeliveryTimeInMinutes,
				MaxDeliveryTimeInMinutes = model.MaxDeliveryTimeInMinutes,
				ImageURL = model.ImageURL,
				RestaurantCategoryId = model.RestaurantCategoryId
			};

			await repository.AddAsync(restaurant);
			await repository.SaveChangesAsync();

			return restaurant.Id;
		}

		public Task EditRestaurantAsync(RestaurantDetailViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteRestaurantAsync(RestaurantDetailViewModel model)
		{
			throw new NotImplementedException();
		}


		public async Task<IEnumerable<RestaurantCategoryModel>> AllRestaurantCategoriesAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.RestaurantCategory>()
				.Select(c => new RestaurantCategoryModel()
				{
					Id = c.Id,
					Title = c.Title,
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<string>> AllRestaurantCategoriesNamesAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.RestaurantCategory>()
				.Select(c => c.Title)
				.Distinct()
				.ToListAsync();
		}

		public async Task<bool> ExistsRestaurantAsync(int id)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.AnyAsync(p => p.Id == id);
		}

		public async Task<bool> ExistsRestaurantCategoryAsync(int categoryId)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.RestaurantCategory>()
				.AnyAsync(p => p.Id == categoryId);
		}

		public async Task<IEnumerable<RestaurantViewModel>> GetAllRestaurantsAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Select(p => new RestaurantViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					MinDeliveryTimeInMinutes = p.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.MaxDeliveryTimeInMinutes,
					ImageURL = p.ImageURL,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<RestaurantViewModel>> GetRestaurantsByCategoryAsync(int categoryId)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(p => p.RestaurantCategoryId == categoryId)
				.Select(p => new RestaurantViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					MinDeliveryTimeInMinutes = p.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.MaxDeliveryTimeInMinutes,
					ImageURL = p.ImageURL,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<RestaurantViewModel>> HighestRatingRestaurantsAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.OrderByDescending(p => p.AverageRating)
				.Select(p => new RestaurantViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					MinDeliveryTimeInMinutes = p.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.MaxDeliveryTimeInMinutes,
					ImageURL = p.ImageURL,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<ItemViewModel>> MenuRestaurantAsync(int restaurantId)
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

		public async Task<(string SanitizedKeyword, IEnumerable<RestaurantViewModel> Results)> SearchRestaurantsAsync(string keyword)
		{
			string sanitizedKeyword = Sanitize(keyword);

			// Split the sanitized keyword into individual words
			var characters = sanitizedKeyword.ToLower().Select(c => c.ToString()).ToArray();

			var query = repository.AllReadOnly<Infrastructure.Data.Models.Restaurant>();

			foreach (var ch in characters)
			{
				var keywordParameter = "%" + ch + "%";

				// Apply the search criteria for each keyword
				query = query
					.Where(p => EF.Functions.Like(p.Title.ToLower(), keywordParameter)
						   || p.Items.Any(i => EF.Functions.Like(i.Title.ToLower(), keywordParameter)
						   || EF.Functions.Like(i.Description.ToLower(), keywordParameter)));
			}

			var results = await query
				.Select(p => new RestaurantViewModel
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					MinDeliveryTimeInMinutes = p.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.MaxDeliveryTimeInMinutes,
					ImageURL = p.ImageURL,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.ToListAsync();

			return (sanitizedKeyword, results);
		}



		public async Task<IEnumerable<RestaurantViewModel>> RestaurantsByServiceFeeAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.OrderBy(p => p.ServiceFee)
				.Select(p => new RestaurantViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					MinDeliveryTimeInMinutes = p.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.MaxDeliveryTimeInMinutes,
					ImageURL = p.ImageURL,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.ToListAsync();
		}

		public async Task<RestaurantViewModel?> GetRestaurantByIdAsync(int id)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(p => p.Id == id)
				.Select(p => new RestaurantViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					ServiceFee = p.ServiceFee,
					MinDeliveryTimeInMinutes = p.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.MaxDeliveryTimeInMinutes,
					ImageURL = p.ImageURL,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					RestaurantCategory = p.RestaurantCategory.Title
				})
				.FirstOrDefaultAsync();
		}

		private string Sanitize(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return string.Empty;
			}

			input = input.Trim();

			input = System.Web.HttpUtility.HtmlEncode(input);

			input = input.Replace("'", "").Replace(";", "");

			const int MaxLength = 255;
			input = input.Length > MaxLength ? input.Substring(0, MaxLength) : input;

			input = input.ToLowerInvariant();

			input = Regex.Replace(input, @"\s+", " ");

			const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
			input = new string(input.Where(c => AllowedChars.Contains(c)).ToArray());

			input = input.Replace("..", "");

			return input;
		}

		public async Task<bool> ExistsCityAsync(int cityId)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.City>()
				.AnyAsync(p => p.Id == cityId);
		}
	}
}