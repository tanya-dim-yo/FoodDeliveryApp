using FoodDeliveryApp.Core.Models.ProductReview;

namespace FoodDeliveryApp.Core.Contracts
{
    public interface IProductReviewService
    {
        Task AddProductReviewAsync(ProductReviewFormModel productReview);
        Task<IEnumerable<ProductReviewViewModel>> GetProductReviewsByProductIdAsync(int productId);
    }
}