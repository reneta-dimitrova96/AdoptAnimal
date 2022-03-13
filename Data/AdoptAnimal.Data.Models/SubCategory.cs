namespace AdoptAnimal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class SubCategory : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
