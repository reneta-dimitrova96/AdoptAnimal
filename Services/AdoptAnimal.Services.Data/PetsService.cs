namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Data.Models.Enums;
    using AdoptAnimal.Web.ViewModels.Pets;

    public class PetsService : IPetsService
    {
        private readonly IDeletableEntityRepository<Pet> petsRepository;
        private readonly IDeletableEntityRepository<PetImage> petImagesRepository;

        public PetsService(IDeletableEntityRepository<Pet> petsRepository, IDeletableEntityRepository<PetImage> petImagesRepository)
        {
            this.petsRepository = petsRepository;
            this.petImagesRepository = petImagesRepository;
        }

        public async Task<int> CreateAsync(CreatePetInputModel input)
        {
            var pet = new Pet
            {
                Name = input.Name,
                Age = input.Age,
                Weight = input.Weight,
                Breed = input.Breed,
                AdvertisementId = input.AdvertisementId != null ? input.AdvertisementId : null,
                IsAdopted = input.IsAdopted,
                CategoryId = input.CategoryId,
            };

            if (input.Images != null)
            {
                foreach (var inputImage in input.Images)
                {
                    var petImage = this.petImagesRepository.All().FirstOrDefault(i => i.Extension == inputImage.Extension);
                    if (petImage == null)
                    {
                        petImage = new PetImage
                        {
                            Extension = inputImage.Extension,
                            Label = inputImage.Label,
                            Pet = pet,
                        };
                        pet.PetImages.Add(petImage);
                    }
                }
            }

            await this.petsRepository.AddAsync(pet);
            await this.petsRepository.SaveChangesAsync();
            return pet.Id;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllGenderTypes()
        {
            var enumElements = new Dictionary<int, string>();
            foreach (string name in Enum.GetNames(typeof(GenderType)))
            {
                int value = (int)Enum.Parse(typeof(GenderType), name);
                enumElements.Add(value, name);
            }

            return enumElements;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllIsDewormedEnumNames()
        {
            var enumElements = new Dictionary<int, string>();
            foreach (string name in Enum.GetNames(typeof(IsDewormed)))
            {
                int value = (int)Enum.Parse(typeof(IsDewormed), name);
                enumElements.Add(value, name);
            }

            return enumElements;
        }

        public GetAllPetsInputModel GetAllPets()
        {
            var data = new GetAllPetsInputModel
            {
                Pets = this.petsRepository.AllAsNoTracking().Select(p => new GetPetInputModel
                {
                    Name = p.Name,
                    Age = p.Age,
                    Weight = p.Weight,
                    Breed = p.Breed,
                    IsAdopted = p.IsAdopted,
                    AdvertisementId = p.AdvertisementId != null ? p.AdvertisementId : null,
                    CategoryId = p.CategoryId,
                }),
            };
            return data;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllPetsAsKeyValuePairs()
        {
            return this.petsRepository.AllAsNoTracking().Select(p => new
            {
                p.Id,
                p.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
