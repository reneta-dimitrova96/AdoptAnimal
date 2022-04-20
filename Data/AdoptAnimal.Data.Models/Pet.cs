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
            this.PetImages = new HashSet<PetImage>();
        }

        public string Name { get; set; }

        public int? Age { get; set; }

        public GenderType Gender { get; set; }

        public double? Weight { get; set; }

        public string Breed { get; set; }

        public IsDewormed IsDewormed { get; set; }

        public bool? IsAdopted { get; set; }

        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<PetImage> PetImages { get; set; }
    }
}
