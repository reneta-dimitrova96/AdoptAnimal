namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(150)]
        public string Content { get; set; }

        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
