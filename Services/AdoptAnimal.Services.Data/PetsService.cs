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

        public PetsService(IDeletableEntityRepository<Pet> petsRepository)
        {
            this.petsRepository = petsRepository;
        }

        public async Task CreateAsync(CreatePetInputModel input)
        {
            var pet = new Pet
            {
                Name = input.Name,
                Age = input.Age,
                Address = input.Address,
                Breed = input.Breed,
                AdvertisementId = input.AdvertisementId,
                IsAdopted = input.IsAdopted,
                CategoryId = input.CategoryId,
            };

            await this.petsRepository.AddAsync(pet);
            await this.petsRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllIsDewormedEnumNames()
        {
            var enumElements = new Dictionary<int, string>();
            foreach (string elName in Enum.GetNames(typeof(IsDewormed)))
            {
                int value = (int)Enum.Parse(typeof(IsDewormed), elName);
                enumElements.Add(value, elName);
            }

            return enumElements;
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
