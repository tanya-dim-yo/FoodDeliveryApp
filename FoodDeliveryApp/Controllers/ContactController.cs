using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.RestaurantErrorMessagesConstants;

namespace FoodDeliveryApp.Controllers
{
	public class ContactController : BaseController
	{
		private readonly IContactService contactService;
		private readonly IRestaurantService restaurantService;

		public ContactController(
			IContactService _contactService,
			IRestaurantService _restaurantService)
		{
			contactService = _contactService;
			restaurantService = _restaurantService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> ContactUs()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Reservation()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account");
			}

			var userId = HttpContext.User.GetUserId();

			if (string.IsNullOrEmpty(userId))
			{
				return Unauthorized();
			}

			string userName = HttpContext.User.Identity.Name;
			string userEmail = HttpContext.User.GetUserEmail();

			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userEmail))
			{
				return Unauthorized();
			}

			var model = new ReservationFormModel()
			{
				Name = userName,
				Email = userEmail,
				Restaurants = await restaurantService.GetRestaurantsAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Reservation(ReservationFormModel model, int restaurantId)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account");
			}

			string userName = Request.Form["userName"];
			string userEmail = Request.Form["userEmail"];

			if (await restaurantService.ExistsRestaurantAsync(restaurantId) == false)
			{
				ModelState.AddModelError(nameof(restaurantId), InvalidRestaurantErrorMessage);
			}

			if (ModelState.IsValid == false)
			{
				model.Restaurants = await restaurantService.GetRestaurantsAsync();
				return View(model);
			}

			model.Name = userName;
			model.Email = userEmail;

			await contactService.ReservationAsync(model);

			return RedirectToAction(nameof(ContactUs));
		}
	}
}