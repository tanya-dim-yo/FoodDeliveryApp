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
		}
	}
}