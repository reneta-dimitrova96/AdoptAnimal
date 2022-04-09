namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.Pets;

    public class AdvertisementService : IAdvertisementService
    {
        private readonly IDeletableEntityRepository<Advertisement> adsRepository;
        private readonly IDeletableEntityRepository<Pet> petsRepository;
        private readonly IRepository<PetImage> petImagesRepository;

        public AdvertisementService(
            IDeletableEntityRepository<Advertisement> adsRepository,
            IDeletableEntityRepository<Pet> petsRepository,
            IRepository<PetImage> petImagesRepository)
        {
            this.adsRepository = adsRepository;
            this.petsRepository = petsRepository;
            this.petImagesRepository = petImagesRepository;
        }

        public async Task CreateAsync(CreateAdvertisementInputModel input, string userId, string imagePath)
        {
            var pet = new Pet
            {
                Name = input.Pet.Name,
                Age = input.Pet.Age,
                Weight = input.Pet.Weight,
                Breed = input.Pet.Breed,
                IsAdopted = input.Pet.IsAdopted,
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
                    Label = input.Title,
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

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var ads = this.adsRepository.AllAsNoTracking()
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
    }
}
