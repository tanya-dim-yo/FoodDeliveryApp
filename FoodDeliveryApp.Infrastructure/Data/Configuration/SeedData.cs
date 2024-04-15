using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
	public class SeedData
	{
		public IdentityUser GuestUser { get; set; }

		public SeedData()
		{
			SeedUsers();
		}

		private void SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			GuestUser = new IdentityUser()
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
