using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryApp.Core.Services
{
	public class ProductService : IProductService
	{
		private readonly IRepository repository;
		private readonly ILogger<ProductService> logger;

		public ProductService(
			IRepository _repository,
			ILogger<ProductService> _logger)
		{
			repository = _repository;
			logger = _logger;
		}

		public async Task<int> AddProductAsync(ProductFormModel model, int restaurantId)
		{
			var product = new Item()
			{
				Title = model.Title,
				Description = model.Description,
				Price = model.Price,
				IsVeggie = model.IsVeggie,
				ImageURL = model.ImageURL,
				RestaurantId = restaurantId,
				ItemCategoryId = model.ItemCategoryId,
				SpicyCategoryId = model.SpicyCategoryId
			};

			await repository.AddAsync(product);
			await repository.SaveChangesAsync();

			return product.Id;
		}

		public Task DeleteProductAsync(int productId)
		{
			throw new NotImplementedException();
		}

		public async Task EditProductAsync(ProductFormModel model, int productId)
		{
			var product = await repository.GetByIdAsync<Item>(productId);

			if (product != null)
			{
				product.Title = model.Title;
				product.Description = model.Description;
				product.Price = model.Price;
				product.IsVeggie = model.IsVeggie;
				product.ImageURL = model.ImageURL;
				product.ItemCategoryId = model.ItemCategoryId;
				product.RestaurantId = model.RestaurantId;
				product.SpicyCategoryId = model.SpicyCategoryId;

				await repository.SaveChangesAsync();
			}
		}

		public async Task<bool> ExistsProductAsync(int productId)
		{
			return await repository
				.AllReadOnly<Item>()
				.AnyAsync(i => i.Id == productId);
		}

		public async Task<bool> ExistsProductCategoryAsync(int productCategoryId)
		{
			return await repository
				.AllReadOnly<ItemCategory>()
				.AnyAsync(i => i.Id == productCategoryId);
		}

		public async Task<bool> ExistsProductSpicyCategoryAsync(int productSpicyCategoryId)
		{
			return await repository
				.AllReadOnly<ItemSpicyCategory>()
				.AnyAsync(i => i.Id == productSpicyCategoryId);
		}

		public async Task<IEnumerable<ProductCategoryViewModel>> GetCategoriesAsync()
		{
			return await repository
				.AllReadOnly<ItemCategory>()
				.Select(c => new ProductCategoryViewModel
				{
					Id = c.Id,
					Title = c.Title
				})
				.ToListAsync();
		}

		public async Task<Item?> GetProductByIdAsync(int productId)
		{
			var product = await repository.GetByIdAsync<Item>(productId);

			return product;
		}

		public async Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(int productId)
		{
			return await repository
				.AllReadOnly<Item>()
				.Where(i => i.Id == productId)
				.Select(p => new ProductDetailsViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Description = p.Description,
					Price = p.Price,
					AverageRating = p.AverageRating,
					TotalReviews = p.TotalReviews,
					IsFavourite = p.IsFavourite,
					IsVeggie = p.IsVeggie,
					ImageURL = p.ImageURL,
					RestaurantId = p.RestaurantId,
					Restaurant = p.Restaurant.Title,
					MinDeliveryTimeInMinutes = p.Restaurant.MinDeliveryTimeInMinutes,
					MaxDeliveryTimeInMinutes = p.Restaurant.MaxDeliveryTimeInMinutes,
					ItemCategory = p.ItemCategory.Title,
					SpicyCategory = p.SpicyCategory.Title
				})
				.FirstOrDefaultAsync();
		}

		public async Task<ProductFormModel?> GetProductFormModelByIdAsync(int productId)
		{
			var product = await repository.AllReadOnly<Item>()
				.Where(p => p.Id == productId)
				.Select(p => new ProductFormModel()
				{
					Title = p.Title,
					Description = p.Description,
					Price = p.Price,
					IsVeggie = p.IsVeggie,
					ImageURL = p.ImageURL,
					ItemCategoryId = p.ItemCategoryId,
					RestaurantId = p.RestaurantId,
					SpicyCategoryId = p.SpicyCategoryId
				})
				.FirstOrDefaultAsync();

			if (product != null)
			{
				product.Categories = await GetCategoriesAsync();
				product.SpicyCategories = await GetSpicyCategoriesAsync();
			}

			return product;
		}

		public async Task<IEnumerable<ProductSpicyCategoryViewModel>> GetSpicyCategoriesAsync()
		{
			return await repository
				.AllReadOnly<ItemSpicyCategory>()
				.Select(c => new ProductSpicyCategoryViewModel
				{
					Id = c.Id,
					Title = c.Title
				})
				.ToListAsync();
		}

		public async Task UpdateFavouriteProductAsync(int productId)
		{
			var product = await repository.GetByIdAsync<Item>(productId);

			if (product == null)
			{
				logger.LogError($"Product with id {productId} not found.");
				return;
			}

			product.IsFavourite = !product.IsFavourite;

			await repository.SaveChangesAsync();
		}
	}
}