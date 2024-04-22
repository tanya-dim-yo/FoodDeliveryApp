using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ReservationValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
	public class Reservation
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(UserIdMaxLength)]
		public string UserId { get; set; } = string.Empty;

		[ForeignKey(nameof(UserId))]
		public virtual ApplicationUser User { get; set; } = null!;

		[Required]
		[MaxLength(UserEmailMaxLength)]
		public string Email { get; set; } = string.Empty;

		[Required]
		public int NumberOfPeople { get; set; }

		[Required]
		[MaxLength(ReservationMessageMaxLength)]
		public string Message { get; set; } = string.Empty;

		[Required]
		public int RestaurantId { get; set; }

		[ForeignKey(nameof(RestaurantId))]
		public virtual Restaurant Restaurant { get; set; } = null!;
	}
}