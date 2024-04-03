using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
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

		public async Task<ProductDetailsViewModel?> GetProductByIdAsync(int productId)
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
					ItemCategory = p.ItemCategory.Title,
					SpicyCategory = p.SpicyCategory.Title
				})
				.FirstOrDefaultAsync();
		}
	}
}
