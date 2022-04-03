namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System.ComponentModel.DataAnnotations;

    public class GetPetInputModel
    {
        public string Name { get; set; }

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public string Breed { get; set; }

        public bool IsAdopted { get; set; }

        public int? AdvertisementId { get; set; }

        public int CategoryId { get; set; }
    }
}
