using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ApplicationUserValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[MaxLength(ApplicationUserFirstNameMaxLength)]
		[PersonalData]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MaxLength(ApplicationUserLastNameMaxLength)]
		[PersonalData]
		public string LastName { get; set; } = string.Empty;
	}
}