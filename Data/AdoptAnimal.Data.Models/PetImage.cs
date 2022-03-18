namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class PetImage : BaseDeletableModel<string>
    {
        [Required]
        public string Extension { get; set; }

        [Required]
        public string Label { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
