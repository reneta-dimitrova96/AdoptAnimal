namespace AdoptAnimal.Services.Data
{
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;

    public interface IAdvertisementService
    {
        Task CreateAsync(CreateAdInputModel input);
    }
}
