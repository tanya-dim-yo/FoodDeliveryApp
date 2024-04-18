using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.City;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static FoodDeliveryApp.Core.Extensions.StringExtensions;

namespace FoodDeliveryApp.Core.Services.Restaurant
{
	public class RestaurantService : IRestaurantService
	{
		private readonly IRepository repository;
		private readonly ILogger<RestaurantService> logger;

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

        public async Task<(IEnumerable<RestaurantViewModel> Restaurants, IEnumerable<(int Id, string Title)> Categories)> GetAllRestaurantsAndCategoriesAsync()
        {
            var model = new ArticlesWithCategoriesViewModel();

            var categories = await AllRestaurantCategoriesAsync();

			var restaurants = await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.ProjectToRestaurantViewModel()
				.ToListAsync();

            model.CategoryNames = categories.Select(c => c.Title);
            model.CategoryIds = categories.Select(c => c.Id);

            return (restaurants, categories.Select(c => (c.Id, c.Title)));
        }

        private async Task<IEnumerable<(int Id, string Title)>> AllRestaurantCategoriesAsync()
		{
			var categories = await repository
				.AllReadOnly<RestaurantCategory>()
				.Select(c => new { c.Id, c.Title })
				.ToListAsync();

			return categories.Select(c => (c.Id, c.Title));
		}

		public async Task<IEnumerable<CityServiceModel>> AllRestaurantCitiesAsync()
		{
			return await repository
				.AllReadOnly<City>()
				.Select(c => new CityServiceModel
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<string>> AllRestaurantCategoriesNamesAsync()
		{
			return await repository
				.AllReadOnly<RestaurantCategory>()
				.OrderBy(c => c.Title)
				.Select(c => c.Title)
				.Distinct()
				.ToListAsync();
		}

		public async Task<IEnumerable<RestaurantViewModel>> GetAllRestaurantsAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.ProjectToRestaurantViewModel()
				.ToListAsync();
		}

		public async Task<IEnumerable<RestaurantViewModel>> GetRestaurantsByCategoryAsync(int categoryId)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(p => p.RestaurantCategoryId == categoryId)
				.ProjectToRestaurantViewModel()
				.ToListAsync();
		}

		public async Task<RestaurantViewModel?> GetRestaurantByIdAsync(int id)
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(p => p.Id == id)
				.ProjectToRestaurantViewModel()
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<ProductViewModel>> MenuRestaurantAsync(int restaurantId)
		{
			return await repository
				.AllReadOnly<Item>()
				.Where(i => i.RestaurantId == restaurantId)
				.Select(i => new ProductViewModel()
				{
					Id = i.Id,
					Title = i.Title,
					Description = i.Description,
					Price = i.Price,
					ImageURL = i.ImageURL,
					ItemCategory = i.ItemCategory.Title
				})
				.ToListAsync();
		}

		public async Task<(string SanitizedKeyword, IEnumerable<RestaurantViewModel> Results)> SearchRestaurantsAsync(string keyword)
		{
			string sanitizedKeyword = Sanitize(keyword);

			var characters = sanitizedKeyword.ToLower().Select(c => c.ToString()).ToArray();

			var query = repository.AllReadOnly<Infrastructure.Data.Models.Restaurant>();

			foreach (var ch in characters)
			{
				var keywordParameter = "%" + ch + "%";

				query = query
					.Where(p => EF.Functions.Like(p.Title.ToLower(), keywordParameter)
						   || p.Items.Any(i => EF.Functions.Like(i.Title.ToLower(), keywordParameter)
						   || EF.Functions.Like(i.Description.ToLower(), keywordParameter)));
			}

			var results = await query
				.ProjectToRestaurantViewModel()
				.ToListAsync();

			return (sanitizedKeyword, results);
		}

		public async Task<IEnumerable<RestaurantViewModel>> RestaurantsByServiceFeeAsync()
		{
			return await repository
				.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.OrderBy(p => p.ServiceFee)
				.ProjectToRestaurantViewModel()
				.ToListAsync();
		}

		public async Task<bool> ExistsCityAsync(int cityId)
		{
			return await repository
				.AllReadOnly<City>()
				.AnyAsync(p => p.Id == cityId);
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
				.AllReadOnly<RestaurantCategory>()
				.AnyAsync(p => p.Id == categoryId);
		}

		public async Task EditRestaurantAsync(int restaurantId, RestaurantFormModel model)
		{
			var restaurant = await repository.GetByIdAsync<Infrastructure.Data.Models.Restaurant>(restaurantId);

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

				await repository.SaveChangesAsync();
			}
		}

		public async Task<RestaurantFormModel?> GetRestaurantFormModelByIdAsync(int restaurantId)
		{
			var restaurant = await repository.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(r => r.Id == restaurantId)
				.Select(r => new RestaurantFormModel()
				{
					Title = r.Title,
					Address = r.Address,
					CityId = r.CityId,
					OpeningHour = r.OpeningHour.ToString("HH:mm"),
					OpenHourDateTime = r.OpeningHour,
					ClosingHour = r.ClosingHour.ToString("HH:mm"),
					CloseHourDateTime = r.ClosingHour,
					Latitude = r.Latitude,
					Longitude = r.Longitude,
					ServiceFee = r.ServiceFee,
					MinDeliveryTimeInMinutes = r.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = r.MaxDeliveryTimeInMinutes,
					ImageURL = r.ImageURL,
					RestaurantCategoryId = r.RestaurantCategoryId
				})
				.FirstOrDefaultAsync();

			if (restaurant != null)
			{
				var categories = await AllRestaurantCategoriesAsync();

				restaurant.Categories = categories
					.Select(c => new RestaurantCategoryViewModel
					{
						Id = c.Id,
						Title = c.Title
					})
					.ToList();

                restaurant.Cities = await AllRestaurantCitiesAsync();
			}

			return restaurant;
		}

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await repository.GetByIdAsync<Infrastructure.Data.Models.Restaurant>(restaurantId);

            if (restaurant == null)
            {
                this.logger.LogError($"Restaurant with id {restaurantId} not found.");
                return;
            }

            var itemsToBeDeleted = await repository
                .AllReadOnly<Item>()
                .Where(i => i.RestaurantId == restaurantId)
                .ToListAsync();

            foreach (var item in itemsToBeDeleted)
            {
                await DeleteRelatedEntitiesAsync(item);
                await repository.DeleteAsync<Item>(item.Id);
            }

            await repository.DeleteAsync<Infrastructure.Data.Models.Restaurant>(restaurant.Id);
            await repository.SaveChangesAsync();
        }

        private async Task DeleteRelatedEntitiesAsync(Item item)
        {
            var addOns = await repository
                .AllReadOnly<ItemAddOn>()
                .Where(a => a.ItemId == item.Id)
                .ToListAsync();

            foreach (var addOn in addOns)
            {
                await repository.DeleteAsync<ItemAddOn>(addOn.ItemId);
            }

            var reviews = await repository
                .AllReadOnly<ItemReview>()
                .Where(r => r.ItemId == item.Id)
                .ToListAsync();

            foreach (var review in reviews)
            {
                await repository.DeleteAsync<ItemReview>(review.Id);
            }

            var cartItems = await repository
                .AllReadOnly<CartItem>()
                .Where(c => c.ItemId == item.Id)
                .ToListAsync();

            foreach (var cartItem in cartItems)
            {
                await repository.DeleteAsync<CartItem>(cartItem.Id);
            }
        }

		public async Task<RestaurantDeleteModel?> GetRestaurantDeleteModelByIdAsync(int restaurantId)
		{
			var restaurant = await repository.AllReadOnly<Infrastructure.Data.Models.Restaurant>()
				.Where(r => r.Id == restaurantId)
				.Include(r => r.City)
				.Include(r => r.RestaurantCategory)
				.Select(r => new RestaurantDeleteModel(
					r.Id,
					r.Title,
					r.Address,
					r.City.Name,
					r.OpeningHour,
					r.ClosingHour,
					r.ServiceFee,
					r.RestaurantCategory.Title))
				.FirstOrDefaultAsync();

			return restaurant;
		}
	}
}