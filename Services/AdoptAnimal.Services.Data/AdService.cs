namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Web.ViewModels.Ads;

    public class AdService : IAdService
    {
        private readonly IDeletableEntityRepository<Ad> adsRepository;

        public AdService(IDeletableEntityRepository<Ad> adsRepository)
        {
            this.adsRepository = adsRepository;
        }

        public async Task CreateAsync(CreateAdInputModel input)
        {
            var ad = new Ad
            {
                Title = input.Title,
                Description = input.Description,
                PetId = input.PetId,
            };
            await this.adsRepository.AddAsync(ad);
            await this.adsRepository.SaveChangesAsync();
        }
    }
}
