namespace AdoptAnimal.Web.ViewModels.SearchAdvertisements
{
    using System.Collections.Generic;

    using AdoptAnimal.Web.ViewModels.Advertisements;

    public class ListViewModel
    {
        public IEnumerable<AdvertisementInListViewModel> Advertisements { get; set; }
    }
}
