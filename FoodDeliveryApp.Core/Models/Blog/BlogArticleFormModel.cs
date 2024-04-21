using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Core.Constants.MessageConstants.BlogArticleMessageConstants;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogArticleValidationConstants;

namespace FoodDeliveryApp.Core.Models.Blog
{
    public class BlogArticleFormModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(BlogArticleTitleMaxLength,
            MinimumLength = BlogArticleTitleMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Заглавие на статията")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Display(Name = "Дата на публикуване")]
        public string PublicationDate { get; set; } = string.Empty;

        public DateTime PublicationDateDT { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(typeof(int),
            BlogArticleReadingTimeMinValue,
            BlogArticleReadingTimeMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = NotValidReadingTimeMessage)]
        [Display(Name = "Време за прочитане на статията в минути")]
        public int ReadingTime { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(BlogArticleContentMaxLength,
            MinimumLength = BlogArticleContentMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Съдържание на статията")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(BlogArticleImageURLMaxLength,
            MinimumLength = BlogArticleImageURLMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Image URL")]
        public string Image { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Display(Name = "Категория")]
        public int BlogArticleCategoryId { get; set; }

        public IEnumerable<BlogArticleCategoryViewModel> Categories { get; set; } = new List<BlogArticleCategoryViewModel>();
    }
}