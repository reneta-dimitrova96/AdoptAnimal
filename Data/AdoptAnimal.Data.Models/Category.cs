namespace AdoptAnimal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Pets = new HashSet<Pet>();
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
