namespace AdoptAnimal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;
    using AdoptAnimal.Data.Models.Enums;

    public class Pet : BaseDeletableModel<int>
    {
        public Pet()
        {
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }

        public string Breed { get; set; }

        public IsDewormed IsDewormed { get; set; }

        public bool IsAdopted { get; set; }

        public int AdForeignKey { get; set; }

        public Ad Ad { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
