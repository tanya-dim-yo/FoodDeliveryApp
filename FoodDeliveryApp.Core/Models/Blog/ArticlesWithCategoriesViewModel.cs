namespace FoodDeliveryApp.Core.Models.Blog
{
    public class ArticlesWithCategoriesViewModel
    {
        public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
        public IEnumerable<BlogArticleViewModel> Articles { get; set; } = new List<BlogArticleViewModel>();
    }
}