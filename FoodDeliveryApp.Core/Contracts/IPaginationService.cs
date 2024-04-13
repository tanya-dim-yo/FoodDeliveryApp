namespace FoodDeliveryApp.Core.Contracts
{
    public interface IPaginationService
    {
        int CurrentPage { get; set; }
        int RestaurantsPerPage { get; set; }
    }
}