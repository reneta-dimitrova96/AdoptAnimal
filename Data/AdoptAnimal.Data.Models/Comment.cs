namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Content { get; set; }

        public int AdvertisementId { get; set; }

        public Advertisement Advertisement { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
