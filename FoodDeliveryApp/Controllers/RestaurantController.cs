﻿using Microsoft.AspNetCore.Mvc;
using FoodDeliveryApp.Models.Restaurant;

namespace FoodDeliveryApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

		public IActionResult Nearest()
		{
			return View();
		}

		public IActionResult HighestRating()
		{
			return View();
		}

		public IActionResult ServiceFee()
		{
			return View();
		}

		public IActionResult GetCategory()
		{
			return View();
		}

		public IActionResult GetRestaurant(int id)
		{
			return View();
		}

		public IActionResult RateRestaurant(int id, double newRating)
		{
			return View();
		}
	}
}
