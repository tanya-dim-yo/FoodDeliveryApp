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

        public static class BlogArticleCategoryValidationConstants
        {
            public const int BlogArticleCategoryTitleMaxLength = 50;
        }

        public static class BlogArticleCommentValidationConstants
        {
            public const int BlogArticleCommentMaxLength = 1000;
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

        public static class LocationValidationConstants
        {
            public const int LocationAddressMaxLength = 100;
        }

		public static class CityValidationConstants
		{
			public const int CityNameMaxLength = 20;
			public const int CityNameMinLength = 3;
		}

		public static class RestaurantValidationConstants
        {
            public const int RestaurantTitleMaxLength = 50;
			public const int RestaurantTitleMinLength = 2;
			public const int RestaurantAddressMaxLength = 100;
			public const int RestaurantAddressMinLength = 10;
            public const int RestaurantDeliveryTimeMaxLength = 20;
            public const int RestaurantBackgroundImageMaxLength = 200;
        }

        public static class RestaurantCategoryValidationConstants
        {
            public const int RestaurantCategoryTitleMaxLength = 50;
        }
    }
}