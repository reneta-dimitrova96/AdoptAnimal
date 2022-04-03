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
        private readonly IDeletableEntityRepository<PetImage> petImagesRepository;

        public AdvertisementService(
            IDeletableEntityRepository<Advertisement> adsRepository,
            IDeletableEntityRepository<Pet> petsRepository,
            IDeletableEntityRepository<PetImage> petImagesRepository)
        {
            this.adsRepository = adsRepository;
            this.petsRepository = petsRepository;
            this.petImagesRepository = petImagesRepository;
        }

        public async Task CreateAsync(CreateAdvertisementInputModel input, string userId)
        {
            var ad = new Advertisement
            {
                Title = input.Title,
                Description = input.Description,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                AuthorId = userId,
            };

            var pet = new Pet
            {
                Name = input.Pet.Name,
                Age = input.Pet.Age,
                Weight = input.Pet.Weight,
                Breed = input.Pet.Breed,
                IsAdopted = input.Pet.IsAdopted,
                CategoryId = input.Pet.CategoryId,
            };

            foreach (var petImage in input.Pet.Images)
            {
                // TODO
            }

            ad.Pet = pet;
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
