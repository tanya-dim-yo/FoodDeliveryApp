namespace FoodDeliveryApp.Core.Contracts
{
    public interface IPaginationService
    {
        int CurrentPage { get; set; }
        void IncrementCurrentPage();
        int RestaurantsPerPage { get; set; }
    }
}