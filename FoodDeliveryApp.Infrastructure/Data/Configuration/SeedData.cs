using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
	public class SeedData
	{
		public ApplicationUser GuestUser { get; set; }

		public SeedData()
		{
			SeedUsers();
		}

		private void SeedUsers()
		{
			var hasher = new PasswordHasher<ApplicationUser>();

			GuestUser = new ApplicationUser()
			{
				Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
				UserName = "guest@mail.com",
				NormalizedUserName = "guest@mail.com",
				Email = "guest@mail.com",
				NormalizedEmail = "guest@mail.com"
			};

			GuestUser.PasswordHash =
			hasher.HashPassword(GuestUser, "guest123");
		}
	}
}
