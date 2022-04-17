namespace AdoptAnimal.Web.ViewModels.Ads
{
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.Pets;

    public class CreateAdvertisementInputModel : BaseAdvertisementInputModel
    {
        public CreatePetInputModel Pet { get; set; }
    }
}
