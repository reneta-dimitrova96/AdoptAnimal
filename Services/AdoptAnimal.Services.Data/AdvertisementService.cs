namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;

    public class AdvertisementService : IAdvertisementService
    {
        private readonly IDeletableEntityRepository<Advertisement> adsRepository;
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public AdvertisementService(
            IDeletableEntityRepository<Advertisement> adsRepository,
            IDeletableEntityRepository<Pet> petsRepository)
        {
            this.adsRepository = adsRepository;
            this.petsRepository = petsRepository;
        }

        public async Task CreateAsync(CreateAdvertisementInputModel input)
        {
            var ad = new Advertisement
            {
                Title = input.Title,
                Description = input.Description,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
            };

            if (input.Pets != null)
            {
                foreach (var pet in input.Pets)
                {
                    var existedPet = this.petsRepository.All().FirstOrDefault(p => p.Id == pet.PetId);
                    ad.Pets.Add(existedPet);
                }
            }

            await this.adsRepository.AddAsync(ad);
            await this.adsRepository.SaveChangesAsync();
        }

        public GetAllAdvertisementsInputModel GetAllAdvertisements()
        {
            var data = new GetAllAdvertisementsInputModel
            {
                Advertisements = this.adsRepository.AllAsNoTracking().Select(a => new GetAdvertisementInputModel
                {
                    Title = a.Title,
                    Description = a.Description,
                    Address = a.Address,
                }),
            };
            return data;
        }
    }
}
