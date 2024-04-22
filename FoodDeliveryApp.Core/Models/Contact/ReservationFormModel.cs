using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Models.Contact
{
    public class ReservationFormModel
	{
		public string UserId { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public int NumberOfPeople { get; set; }
		public string Message { get; set; } = string.Empty;
		public int RestaurantID { get; set; }
		public virtual IEnumerable<RestaurantReservationViewModel> Restaurants { get; set; } = new List<RestaurantReservationViewModel>();
	}
}