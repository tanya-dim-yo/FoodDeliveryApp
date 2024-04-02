using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace FoodDeliveryApp.Core.Services.Restaurant
{
	public class RestaurantService : IRestaurantService
	{
		private readonly IRepository _repository;
		private readonly ILogger<RestaurantService> _logger;

		public RestaurantService(
			IRepository repository,
			ILogger<RestaurantService> logger)
		{
			_repository = repository;
			_logger = logger;
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

			await _repository.AddAsync(restaurant);
			await _repository.SaveChangesAsync();

			return restaurant.Id;
		}

		public async Task<(IEnumerable<RestaurantViewModel> Restaurants, IEnumerable<(int Id, string Title)> Categories)> GetAllRestaurantsAndCategoriesAsync()
		{
			var restaurants = await GetAllRestaurantsAsync();
			var categories = await AllRestaurantCategoriesAsync();

			return (restaurants, categories);
		}

		private async Task<IEnumerable<(int Id, string Title)>> AllRestaurantCategoriesAsync()
		{
			var categories = await _repository
				.AllReadOnly<Infrastructure.Data.Models.RestaurantCategory>()
				.Select(c => new { c.Id, c.Title })
				.ToListAsync();

			return categories.Select(c => (c.Id, c.Title));
		}

		public async Task<IEnumerable<string>> AllRestaurantCategoriesNamesAsync()
		{
			return await _repository
				.AllReadOnly<Infrastructure.Data.Models.RestaurantCategory>()
				.OrderBy(c => c.Title)
				.Select(c => c.Title)
				.Distinct()
				.ToListAsync();
		}

		public async Task<IEnumerable<RestaurantViewModel>> GetAllRestaurantsAsync()
		{
			return await _repository
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
			return await _repository
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

		public async Task<RestaurantViewModel?> GetRestaurantByIdAsync(int id)
		{
			return await _repository
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

		public async Task<IEnumerable<RestaurantViewModel>> HighestRatingRestaurantsAsync()
		{
			return await _repository
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
			return await _repository
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
			var restaurant = await _repository.All<Infrastructure.Data.Models.Restaurant>()
				.FirstOrDefaultAsync(r => r.Id == restaurantId);

			if (restaurant == null)
			{
				throw new Exception("Restaurant not found.");
			}

			restaurant.UpdateRating(newRating);

			await _repository.SaveChangesAsync();
		}

		public async Task<(string SanitizedKeyword, IEnumerable<RestaurantViewModel> Results)> SearchRestaurantsAsync(string keyword)
		{
			string sanitizedKeyword = Sanitize(keyword);

			var characters = sanitizedKeyword.ToLower().Select(c => c.ToString()).ToArray();

			var query = _repository.AllReadOnly<Infrastructure.Data.Models.Restaurant>();

			foreach (var ch in characters)
			{
				var keywordParameter = "%" + ch + "%";

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
			return await _repository
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
			return await _repository
				.AllReadOnly<Infrastructure.Data.Models.City>()
				.AnyAsync(p => p.Id == cityId);
		}

		public async Task<bool> ExistsRestaurantAsync(int id)
		{
			return await _repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.AnyAsync(p => p.Id == id);
		}

		public async Task<bool> ExistsRestaurantCategoryAsync(int categoryId)
		{
			return await _repository
				.AllReadOnly<Infrastructure.Data.Models.RestaurantCategory>()
				.AnyAsync(p => p.Id == categoryId);
		}

		public async Task EditAsync(int restaurantId, RestaurantFormModel model)
		{
			var restaurant = await _repository.GetByIdAsync<Infrastructure.Data.Models.Restaurant>(restaurantId);

			if (restaurant != null)
			{
				restaurant.Title = model.Title;
				restaurant.Address = model.Address;
				restaurant.CityId = model.CityId;
				restaurant.OpeningHour = model.OpenHourDateTime;
				restaurant.ClosingHour = model.CloseHourDateTime;
				restaurant.Latitude = model.Latitude;
				restaurant.Longitude = model.Longitude;
				restaurant.ServiceFee = model.ServiceFee;
				restaurant.MinDeliveryTimeInMinutes = model.MinDeliveryTimeInMinutes;
				restaurant.MaxDeliveryTimeInMinutes = model.MaxDeliveryTimeInMinutes;
				restaurant.ImageURL = model.ImageURL;
				restaurant.RestaurantCategoryId = model.RestaurantCategoryId;

				await _repository.SaveChangesAsync();
			}
		}
	}
}
