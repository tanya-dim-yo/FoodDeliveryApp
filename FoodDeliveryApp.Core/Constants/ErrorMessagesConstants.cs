﻿namespace FoodDeliveryApp.Core.Constants
{
	public static class ErrorMessagesConstants
	{
		public static class RestaurantErrorMessagesConstants
		{
			public const string InvalidCategoryErrorMessage = "Категорията не съществува.";
			public const string InvalidRestaurantErrorMessage = "Ресторантът не съществува.";
		}

		public static class ProductErrorMessagesConstants
		{
			public const string InvalidProductErrorMessage = "Продуктът не съществува.";
			public const string InvalidProductCategoryErrorMessage = "Категорията на продукта не съществува.";
		}
	}
}