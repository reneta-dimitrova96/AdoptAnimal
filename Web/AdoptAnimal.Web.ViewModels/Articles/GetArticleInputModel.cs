namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    public class GetArticleInputModel
    {

        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
