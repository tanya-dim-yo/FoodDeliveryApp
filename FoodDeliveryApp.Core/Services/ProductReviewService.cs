using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.ProductReview;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryApp.Core.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IRepository repository;
        private readonly ILogger<ProductReviewService> logger;

        public ProductReviewService(
            IRepository _repository,
            ILogger<ProductReviewService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        public async Task AddProductReviewAsync(ProductReviewFormModel model, int productId)
        {
            var productReview = new ItemReview()
            {
                AverageRating = model.AverageRating,
                Review = model.Review,
                ItemId = productId
            };

            await repository.AddAsync(productReview);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductReviewViewModel>> GetProductReviewsByProductIdAsync(int productId)
        {
            return await repository
                .AllReadOnly<ItemReview>()
                .Where(i => i.ItemId == productId)
                .Select(c => new ProductReviewViewModel
                {
                    Id = c.Id,
                    AverageRating = c.AverageRating,
                    Review = c.Review
                })
                .ToListAsync();
        }
    }
}