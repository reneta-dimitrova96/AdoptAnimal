namespace AdoptAnimal.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AdoptAnimal.Web.ViewModels.Advertisements;

    public class IndexViewModel
    {
        public int AdsCount { get; set; }

        public int CategoriesCount { get; set; }

        public int AdoptAnimalsCount { get; set; }

        public int UsersCount { get; set; }

        public IEnumerable<AdvertisementInListViewModel> RecentAdvertisements { get; set; }
    }
}
