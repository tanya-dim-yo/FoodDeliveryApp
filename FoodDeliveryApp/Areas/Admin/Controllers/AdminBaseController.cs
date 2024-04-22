using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodDeliveryApp.Core.Constants.RoleConstants;

namespace FoodDeliveryApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRole)]
	public class AdminBaseController : Controller
	{

	}
}