using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public static class AddOnValidationConstants
        {
            public const int AddOnTitleMaxLength = 50;
            public const int AddOnImageMaxLength = 200;
        }

        public static class BlogArticleValidationConstants
        {
            public const int BlogArticleTitleMaxLength = 100;
            public const int BlogArticleContentMaxLength = 6000;
            public const int BlogArticleImageMaxLength = 200;
        }

        public static class BlogCategoryValidationConstants
        {
            public const int BlogCategoryTitleMaxLength = 50;
        }

        public static class BlogCommentValidationConstants
        {
            public const int BlogCommentMaxLength = 1000;
        }

        public static class CouponValidationConstants
        {
            public const int CodeMaxLength = 10;
        }

        public static class ItemValidationConstants
        {
            public const int ItemTitleMaxLength = 50;
            public const int ItemDescriptionMaxLength = 500;
            public const int ItemImageMaxLength = 200;
        }

        public static class ItemCategoryValidationConstants
        {
            public const int ItemCategoryTitleMaxLength = 50;
        }

        public static class ItemReviewValidationConstants
        {
            public const int ItemReviewEmailMaxLength = 320;
            public const int ItemReviewMaxLength = 1000;
        }

        public static class ItemSpicyCategoryValidationConstants
        {
            public const int ItemSpicyCategoryTitleMaxLength = 20;
        }

        public static class RestaurantCategoryValidationConstants
        {
            public const int RestaurantCategoryNameMaxLength = 50;
        }
    }
}