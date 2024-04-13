using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.ProductReview;

namespace FoodDeliveryApp.Core.Services
{
    public class ProductReviewService : IProductReviewService
    {
        public Task AddProductReviewAsync(ProductReviewFormModel productReview)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductReviewViewModel>> GetProductReviewsByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}