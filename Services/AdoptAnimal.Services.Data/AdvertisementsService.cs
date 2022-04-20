namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;

    public class AdvertisementsService : IAdvertisementsService
    {
        private readonly IDeletableEntityRepository<Advertisement> adsRepository;
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public AdvertisementsService(
            IDeletableEntityRepository<Advertisement> adsRepository,
            IDeletableEntityRepository<Pet> petsRepository)
        {
            this.adsRepository = adsRepository;
            this.petsRepository = petsRepository;
        }

        public async Task CreateAsync(CreateAdvertisementInputModel input, string userId, string imagePath)
        {
            var pet = new Pet
            {
                Name = input.Pet.Name,
                Age = input.Pet.Age,
                Weight = input.Pet.Weight,
                Breed = input.Pet.Breed,
                CategoryId = input.Pet.CategoryId,
            };

            var allowedExtension = new[] { "jpg", "png" };
            foreach (var image in input.Pet.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!allowedExtension.Any(x => extension.EndsWith(extension)))
                {
                    throw new Exception($"Invalid image extension {extension}!");
                }

                var petImage = new PetImage
                {
                    AuthorId = userId,
                    Extension = extension,
                };

                pet.PetImages.Add(petImage);

                Directory.CreateDirectory(Path.GetDirectoryName($"{imagePath}/pets/"));
                var physicalPath = $"{imagePath}/pets/{petImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            var ad = new Advertisement
            {
                Title = input.Title,
                Description = input.Description,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                AuthorId = userId,
                Pet = pet,
            };
            await this.adsRepository.AddAsync(ad);
            await this.adsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllAdvertisements<T>(int page, int itemsPerPage = 12)
        {
            var ads = this.adsRepository.AllAsNoTracking()
                .Where(a => a.Pet.IsAdopted != true)
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return ads;
        }

        public int GetAdsCount()
        {
            return this.adsRepository.AllAsNoTracking().Count();
        }

        public T GetById<T>(int id)
        {
            var advertisement = this.adsRepository.AllAsNoTracking()
                .Where(a => a.Id == id)
                .To<T>()
                .FirstOrDefault();
            return advertisement;
        }

        public async Task UpdateAsync(int id, EditAdvertisementInputModel input)
        {
            var advertisement = this.adsRepository.All().FirstOrDefault(a => a.Id == id);
            advertisement.Title = input.Title;
            advertisement.Description = input.Description;
            advertisement.PhoneNumber = input.PhoneNumber;
            advertisement.Address = input.Address;

            var pet = this.petsRepository.All().FirstOrDefault(p => p.AdvertisementId == id);
            pet.IsAdopted = input.PetIsAdopted;

            await this.adsRepository.SaveChangesAsync();
            await this.petsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetByUserId<T>(string userId)
        {
            var userAdvertisements = this.adsRepository.AllAsNoTracking()
                .Where(a => a.AuthorId == userId)
                .To<T>()
                .ToList();
            return userAdvertisements;
        }

        public IEnumerable<T> GetRecentAdvertisements<T>()
        {
            var recentAds = this.adsRepository.AllAsNoTracking()
                .Where(a => a.Pet.IsAdopted != true)
                .OrderByDescending(a => a.CreatedOn)
                .Take(6)
                .To<T>()
                .ToList();
            return recentAds;
        }

        public IEnumerable<T> GetByCategory<T>(int categoryId)
        {
            var advertisements = this.adsRepository.All()
                .Where(a => a.Pet.CategoryId == categoryId)
                .OrderByDescending(a => a.CreatedOn)
                .To<T>()
                .ToList();
            return advertisements;
        }

        public async Task DeleteAsync(int id)
        {
            var advertisement = this.adsRepository.All()
                .FirstOrDefault(a => a.Id == id);
            this.adsRepository.Delete(advertisement);
            await this.adsRepository.SaveChangesAsync();
        }

        public bool IsAuthorOfAd(int advertisementId, string userId)
        {
            var advertisement = this.adsRepository.All()
                .Where(a => a.Id == advertisementId && a.AuthorId == userId)
                .FirstOrDefault();
            return advertisement != null;
        }
    }
}
