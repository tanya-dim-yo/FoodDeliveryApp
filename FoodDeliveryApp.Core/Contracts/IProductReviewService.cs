﻿using FoodDeliveryApp.Core.Models.ProductReview;

namespace FoodDeliveryApp.Core.Contracts
{
    public interface IProductReviewService
    {
        Task AddProductReviewAsync(ProductReviewFormModel model, int productId);
        Task<IEnumerable<ProductReviewViewModel>> GetProductReviewsByProductIdAsync(int productId);
    }
}