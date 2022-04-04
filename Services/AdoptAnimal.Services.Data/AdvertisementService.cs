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
    using AdoptAnimal.Web.ViewModels.Pets;

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

        public IEnumerable<AdvertisementInListViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var ads = this.adsRepository.AllAsNoTracking()
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(a => new AdvertisementInListViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Address = a.Address,
                    Pet = new PetInListShortViewModel
                    {
                        PetId = a.Pet.Id,
                        CategoryName = a.Pet.Category.Name,
                        ImageUrl = a.Pet.PetImages.FirstOrDefault().ImageUrl != null ?
                        a.Pet.PetImages.FirstOrDefault().ImageUrl :
                        "images/advertisements" + a.Pet.PetImages.FirstOrDefault().Id + "." + a.Pet.PetImages.FirstOrDefault().Extension,
                    },
                });
            return ads;
        }

        /*
        public AdvertisementsListViewModel GetAllAdvertisements()
        {
            var data = new AdvertisementsListViewModel
            {
                Advertisements = this.adsRepository.AllAsNoTracking().Select(a => new AdvertisementInListViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Address = a.Address,
                    Pet = new PetInListShortViewModel
                    {
                        PetId = a.Pet.Id,
                        CategoryName = a.Pet.Category.Name,
                        PetImages = a.Pet.PetImages.Select(pi => new PetImageViewModel
                        {
                            Id = pi.Id,
                            Extension = pi.Extension,
                            Label = pi.Label,
                        }).ToList(),
                    },
                }),
            };
            return data;
        }
        */
    }
}
