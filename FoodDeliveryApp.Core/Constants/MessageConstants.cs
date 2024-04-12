namespace FoodDeliveryApp.Core.Constants
{
	public static class MessageConstants
	{
		public static class RestaurantMessageConstants
		{
			public const string RequiredFieldMessage = "Полето {0} е задължително!";
			public const string LengthMessage = "Полето {0} трябва да бъде с дължина между {2} и {1} символа.";
			public const string ServiceFeeMessage = "Цената за доставка трябва да бъде между {2} и {1} лв.";
			public const string DeliveryTimeMessage = "Времето за доставка трябва да бъде между {2} и {1} мин.";
			public const string InvalidCityMessage = "Невалиден град!";
			public const string InvalidRestaurantCategoryMessage = "Невалидена категория!";
			public const string InvalidTimeMessage = "Невалиден час!";
			public const string InvalidSameTimeMessage = "Часът на отваряне и затваряне трябва да бъдат различни!";
			public const string OpenHourBiggerMessage = "Часът на отваряне трябва да бъде по-малък от часът на затваряне!";
			public const string RestaurantsSortedByHighestRatingMessage = "Сортиране по най-висок рейтинг";
			public const string RestaurantsSortedByServiceFeeMessage = "Сортиране по такса за доставка";
			public const string RestaurantCategoryMessage = "Категория: {0}";
		}

		public static class ProductMessageConstants
		{
			public const string RequiredFieldMessage = "Полето {0} е задължително!";
			public const string LengthMessage = "Полето {0} трябва да бъде с дължина между {2} и {1} символа.";
			public const string ProductPriceMinValue = "0.00";
			public const string ProductPriceMaxValue = "100.00";
			public const string InvalidPriceMessage = "Цената на продукта трябва да бъде между {2} и {1} лв.";
			public const string InvalidCategoryMessage = "Невалидна категория!";
			public const string InvalidSpicyCategoryMessage = "Невалидна категория за степен на лютивост!";
			public const string InvalidRestaurantMessage = "Невалиден ресторант!";
		}

		public static class ProductReviewMessageConstants
		{
			public const string RequiredFieldMessage = "Полето {0} е задължително!";
			public const string LengthMessage = "Полето {0} трябва да бъде с дължина между {2} и {1} символа.";
			public const string RatingMinValue = "1";
			public const string RatingMaxValue = "5";
			public const string RatingMessage = "Оценката трябва да бъде между {2} и {1}.";
		}
	}
}