namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System.Collections.Generic;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class PetDetailsViewModel : IMapFrom<Pet>
    {
        public string Name { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public double? Weight { get; set; }

        public string Breed { get; set; }

        public string IsDewormed { get; set; }

        public bool IsAdopted { get; set; }

        public int AdvertisementId { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<PetImageViewModel> PetImages { get; set; }
    }
}
