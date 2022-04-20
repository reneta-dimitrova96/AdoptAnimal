namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;

    public interface IAdvertisementsService
    {
        Task CreateAsync(CreateAdvertisementInputModel input, string userId, string imagePath);

        Task UpdateAsync(int id, EditAdvertisementInputModel input);

        Task DeleteAsync(int id);

        T GetById<T>(int id);

        int GetAdsCount();

        bool IsAuthorOfAd(int advertisementId, string userId);

        IEnumerable<T> GetAllAdvertisements<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetRecentAdvertisements<T>();

        IEnumerable<T> GetByUserId<T>(string userId);

        IEnumerable<T> GetByCategory<T>(int categoryId);
    }
}
