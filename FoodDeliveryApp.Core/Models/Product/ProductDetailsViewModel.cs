using FoodDeliveryApp.Core.Models.ProductReview;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemReviewValidationConstants;
using static FoodDeliveryApp.Core.Constants.MessageConstants.ProductReviewMessageConstants;

namespace FoodDeliveryApp.Core.Models.Product
{
	public class ProductDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public double AverageRating { get; set; }

		public int TotalReviews { get; set; }

		public bool IsFavourite { get; set; }

		public bool IsVeggie { get; set; }

		public string ImageURL { get; set; } = string.Empty;

		public string ItemCategory { get; set; } = string.Empty;

		public int RestaurantId { get; set; }

		public string Restaurant { get; set; } = string.Empty;

		public int MinDeliveryTimeInMinutes { get; set; }

		public int MaxDeliveryTimeInMinutes { get; set; }

		public string SpicyCategory { get; set; } = string.Empty;

		public double AverageRatingPercent => (AverageRating / 5) * 100;

		public IEnumerable<ProductReviewViewModel> Reviews { get; set; } = new List<ProductReviewViewModel>();

		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(typeof(double),
			RatingMinValue,
			RatingMaxValue,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = RatingMessage)]
		[Display(Name = "Добавете оценка за продукта")]
		public double SetAverageRating { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ItemReviewMaxLength,
			MinimumLength = ItemReviewMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Добавете Вашият коментар за продукта.")]
		public string Review { get; set; } = string.Empty;
	}
}