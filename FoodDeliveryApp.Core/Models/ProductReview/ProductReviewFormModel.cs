using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Core.Constants.MessageConstants.ProductReviewMessageConstants;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemReviewValidationConstants;

namespace FoodDeliveryApp.Core.Models.ProductReview
{
	public class ProductReviewFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(typeof(double),
			RatingMinValue,
			RatingMaxValue,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = RatingMessage)]
		[Display(Name = "Добавете оценка за продукта")]
		public double AverageRating { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ItemReviewMaxLength,
			MinimumLength = ItemReviewMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Добавете Вашият коментар за продукта.")]
		public string Review { get; set; } = string.Empty;
	}
}