using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Areas.Admin.Components
{
    public class AdminMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}