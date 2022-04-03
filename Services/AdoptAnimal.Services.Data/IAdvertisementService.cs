namespace AdoptAnimal.Services.Data
{
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;

    public interface IAdvertisementService
    {
        Task CreateAsync(CreateAdvertisementInputModel input, string userId);

        GetAllAdvertisementsInputModel GetAllAdvertisements();
    }
}
