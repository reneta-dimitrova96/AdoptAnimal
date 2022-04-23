namespace AdoptAnimal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(800)]
        public string Content { get; set; }

        public string Source { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
