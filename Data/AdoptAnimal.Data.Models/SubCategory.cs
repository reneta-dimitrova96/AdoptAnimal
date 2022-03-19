namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class SubCategory : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
