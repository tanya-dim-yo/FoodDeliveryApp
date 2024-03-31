using FoodDeliveryApp.Core.Models.City;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Core.Constants.MessageConstants.RestaurantMessageConstants;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.RestaurantValidationConstants;

namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(RestaurantTitleMaxLength,
			MinimumLength = RestaurantTitleMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Име на ресторанта")]
		public string Title { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(RestaurantAddressMaxLength,
			MinimumLength = RestaurantAddressMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Адрес")]
		public string Address { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Град")]
		public int CityId { get; set; }


		public IEnumerable<CityServiceModel> Cities { get; set; } = new List<CityServiceModel>();


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Час на отваряне")]
		public string OpeningHour { get; set; } = string.Empty;

		public DateTime OpenHourDateTime { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Час на затваряне")]
		public string ClosingHour { get; set; } = string.Empty;

		public DateTime CloseHourDateTime { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		public double Latitude { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		public double Longitude { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(typeof(decimal),
			RestaurantServiceFeeMinValue,
			RestaurantServiceFeeMaxValue,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = ServiceFeeMessage)]
		[Display(Name = "Такса доставка")]
		public decimal ServiceFee { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(typeof(int),
			RestaurantDeliveryTimeMinValue,
			RestaurantDeliveryTimeMaxValue,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = DeliveryTimeMessage)]
		[Display(Name = "Минимално време за доставка")]
		public int MinDeliveryTimeInMinutes { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(typeof(int),
			RestaurantDeliveryTimeMinValue,
			RestaurantDeliveryTimeMaxValue,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = DeliveryTimeMessage)]
		[Display(Name = "Максимално време за доставка")]
		public int MaxDeliveryTimeInMinutes { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(RestaurantImageURLMaxLength,
			MinimumLength = RestaurantImageURLMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Image URL")]
		public string ImageURL { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Категория")]
		public int RestaurantCategoryId { get; set; }


		public IEnumerable<RestaurantCategoryModel> Categories { get; set; } = new List<RestaurantCategoryModel>();
	}
}