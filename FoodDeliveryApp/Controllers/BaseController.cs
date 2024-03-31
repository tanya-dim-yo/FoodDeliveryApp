using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{

	}
}