using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantSearchResult
	{
		public string SanitizedKeyword { get; set; } = string.Empty;
		public virtual IEnumerable<RestaurantViewModel> Results { get; set; } = new List<RestaurantViewModel>();
	}
}