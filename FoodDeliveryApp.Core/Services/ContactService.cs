using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Contact;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Services
{
	public class ContactService : IContactService
	{
		private readonly IRepository repository;

		public ContactService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task ReservationAsync(ReservationFormModel model)
		{

			var reservation = new Reservation()
			{
				UserId = model.UserId,
				Email = model.Email,
				NumberOfPeople = model.NumberOfPeople,
				Message = model.Message,
				RestaurantId = model.RestaurantID
			};

			await repository.AddAsync(reservation);
			await repository.SaveChangesAsync();
		}
	}
}