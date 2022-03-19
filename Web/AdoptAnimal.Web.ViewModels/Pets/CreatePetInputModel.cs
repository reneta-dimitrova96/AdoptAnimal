namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Models.Enums;

    public class CreatePetInputModel
    {
        public string Name { get; set; }

        public int? Age { get; set; }

        public IEnumerable<KeyValuePair<int, string>> GenderTypes { get; set; }

        public double? Weight { get; set; }

        public string Breed { get; set; }

        public int AdvertisementId { get; set; }

        public IEnumerable<KeyValuePair<int, string>> IsDewormed { get; set; }

        public bool IsAdopted { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<PetImagesInputModel> Images { get; set; }
    }
}
