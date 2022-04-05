namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System;
    using System.Collections.Generic;

    public class AdvertisementsListViewModel : PagingViewModel
    {
        public IEnumerable<AdvertisementInListViewModel> Advertisements { get; set; }
    }
}
