namespace AdoptAnimal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
            this.ArticleImages = new HashSet<ArticleImage>();
        }

        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(500)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<ArticleImage> ArticleImages { get; set; }
    }
}
