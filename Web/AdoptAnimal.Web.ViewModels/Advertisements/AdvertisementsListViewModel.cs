namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System.Collections.Generic;

    public class AdvertisementsListViewModel
    {
        public IEnumerable<AdvertisementInListViewModel> Advertisements { get; set; }

        public int PageNumber { get; set; }
    }
}
