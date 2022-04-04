namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class PetImage : BaseDeletableModel<string>
    {
        [Required]
        [MinLength(3)]
        public string Extension { get; set; }


        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Label { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
