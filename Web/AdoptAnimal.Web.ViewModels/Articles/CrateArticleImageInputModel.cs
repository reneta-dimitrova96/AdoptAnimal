namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    public class CrateArticleImageInputModel
    {
        [Required]
        [MinLength(3)]
        public string Source { get; set; }
    }
}
