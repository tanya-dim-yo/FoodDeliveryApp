using FoodDeliveryApp.Core.Contracts;

namespace FoodDeliveryApp.Core.Services
{
    public class PaginationService : IPaginationService
    {
        public int CurrentPage { get; set; } = 1;
        public int RestaurantsPerPage { get; set; } = 6;
    }
}