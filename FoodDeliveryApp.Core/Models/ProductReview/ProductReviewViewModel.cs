namespace FoodDeliveryApp.Core.Models.ProductReview
{
	public class ProductReviewViewModel
	{
		public int Id { get; set; }

		public string UserName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public double AverageRating { get; private set; }

		public string Review { get; set; } = string.Empty;
	}
}