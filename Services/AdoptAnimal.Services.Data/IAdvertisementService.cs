namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;

    public interface IAdvertisementService
    {
        Task CreateAsync(CreateAdvertisementInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetAdsCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditAdvertisementInputModel input);
    }
}
