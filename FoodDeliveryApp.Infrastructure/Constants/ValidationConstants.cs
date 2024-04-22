namespace FoodDeliveryApp.Infrastructure.Constants
{
    public static class ValidationConstants
    {
		public static class ApplicationUserValidationConstants
		{
			public const int ApplicationUserFirstNameMaxLength = 50;
			public const int ApplicationUserFirstNameMinLength = 2;
			public const int ApplicationUserLastNameMaxLength = 50;
			public const int ApplicationUserLastNameMinLength = 2;
		}

		public static class AddOnValidationConstants
        {
            public const int AddOnTitleMaxLength = 50;
            public const int AddOnImageMaxLength = 200;
        }

        public static class BlogArticleValidationConstants
        {
            public const int BlogArticleTitleMaxLength = 100;
            public const int BlogArticleTitleMinLength = 2;
            public const int BlogArticleContentMaxLength = 15000;
            public const int BlogArticleContentMinLength = 600;
            public const int BlogArticleImageURLMaxLength = 200;
            public const int BlogArticleImageURLMinLength = 10;
            public const string BlogArticleReadingTimeMaxValue = "10";
            public const string BlogArticleReadingTimeMinValue = "1";
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
			public const int ItemTitleMinLength = 2;
			public const int ItemDescriptionMaxLength = 500;
			public const int ItemDescriptionMinLength = 10;
			public const int ItemImageMaxLength = 200;
			public const int ProductImageURLMaxLength = 200;
			public const int ProductImageURLMinLength = 10;
		}

        public static class ItemCategoryValidationConstants
        {
            public const int ItemCategoryTitleMaxLength = 50;
        }

        public static class ItemReviewValidationConstants
        {
			public const int ItemReviewMinLength = 2;
			public const int ItemReviewMaxLength = 1000;
			public const int ItemReviewEmailMaxLength = 320;
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
			public const string RestaurantServiceFeeMinValue = "0.00";
			public const string RestaurantServiceFeeMaxValue = "20.00";
			public const int RestaurantAddressMaxLength = 100;
			public const int RestaurantAddressMinLength = 10;
            public const string RestaurantDeliveryTimeMaxValue = "120";
			public const string RestaurantDeliveryTimeMinValue = "10";
			public const int RestaurantImageURLMaxLength = 200;
			public const int RestaurantImageURLMinLength = 10;
            public const string DateTimeFormat = "HH:mm";
		}

        public static class RestaurantCategoryValidationConstants
        {
            public const int RestaurantCategoryTitleMaxLength = 50;
        }

		public static class ReservationValidationConstants
		{
			public const int UserIdMaxLength = 450;
			public const int UserEmailMaxLength = 256;
			public const int ReservationMessageMaxLength = 600;
		}

		public static class CartValidationConstants
		{
			public const int UserIdMaxLength = 450;
		}

		public static class OrderValidationConstants
		{
			public const int UserIdMaxLength = 450;
		}
	}
}