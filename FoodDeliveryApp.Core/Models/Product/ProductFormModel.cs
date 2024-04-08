using FoodDeliveryApp.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Core.Constants.MessageConstants.ProductMessageConstants;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemValidationConstants;
using FoodDeliveryApp.Core.Models.Product;

namespace FoodDeliveryApp.Core.Models.Product
{
	public class ProductFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ItemTitleMaxLength,
			MinimumLength = ItemTitleMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Име на продукта")]
		public string Title { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ItemDescriptionMaxLength,
			MinimumLength = ItemDescriptionMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Описание на продукта")]
		public string Description { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(typeof(decimal),
			ProductPriceMinValue,
			ProductPriceMaxValue,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = InvalidPriceMessage)]
		[Display(Name = "Цена на продукта")]
		public decimal Price { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Вегетарианско ястие или ястие съдържащо животински продукти.")]
		public bool IsVeggie { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ProductImageURLMaxLength,
			MinimumLength = ProductImageURLMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Image URL")]
		public string ImageURL { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Категория")]
		public int ItemCategoryId { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Ресторант")]
		public int RestaurantId { get; set; }


		[Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Степен на лютивост")]
		public int SpicyCategoryId { get; set; }


		public IEnumerable<ProductCategoryViewModel> Categories { get; set; } = new List<ProductCategoryViewModel>();


		public IEnumerable<ProductSpicyCategoryViewModel> SpicyCategories { get; set; } = new List<ProductSpicyCategoryViewModel>();
	}
}