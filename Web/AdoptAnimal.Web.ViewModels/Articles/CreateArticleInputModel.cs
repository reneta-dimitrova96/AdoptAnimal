namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Content { get; set; }

        public string Source { get; set; }

        public string ImageUrl { get; set; }
    }
}
