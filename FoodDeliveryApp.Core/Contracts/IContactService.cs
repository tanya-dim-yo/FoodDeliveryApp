using FoodDeliveryApp.Core.Models.Contact;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IContactService
	{
		Task ReservationAsync(ReservationFormModel model);
	}
}
