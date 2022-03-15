namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Web.ViewModels.Ads;

    public class AdvertisementService : IAdvertisementService
    {
        private readonly IDeletableEntityRepository<Advertisement> adsRepository;

        public AdvertisementService(IDeletableEntityRepository<Advertisement> adsRepository)
        {
            this.adsRepository = adsRepository;
        }

        public async Task CreateAsync(CreateAdInputModel input)
        {
            var ad = new Advertisement
            {
                Title = input.Title,
                Description = input.Description,
            };
            await this.adsRepository.AddAsync(ad);
            await this.adsRepository.SaveChangesAsync();
        }
    }
}
