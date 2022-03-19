namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class ArticleImage : BaseDeletableModel<string>
    {
        [Required]
        [MinLength(3)]
        public string Extension { get; set; }

        public string Source { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
