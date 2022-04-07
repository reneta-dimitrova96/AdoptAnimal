namespace AdoptAnimal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class ArticleImage
    {
        public ArticleImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Source { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
