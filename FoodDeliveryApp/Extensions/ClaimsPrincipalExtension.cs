using static FoodDeliveryApp.Core.Constants.RoleConstants;

namespace System.Security.Claims
{
	public static class ClaimsPrincipalExtension
	{
		public static string GetUserId(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}