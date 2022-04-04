﻿namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;

    public interface IAdvertisementService
    {
        Task CreateAsync(CreateAdvertisementInputModel input, string userId);

        IEnumerable<AdvertisementInListViewModel> GetAll(int page, int itemsPerPage = 12);
    }
}
