using System.Security.Claims;

namespace FoodDeliveryApp.Extensions
{
	public static class ClaimsPrincipalExtension
	{
		public static string GetUserId(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}