namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Data.Models.Enums;
    using AdoptAnimal.Services.Mapping;

    public class PetsService : IPetsService
    {
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public PetsService(IDeletableEntityRepository<Pet> petsRepository)
        {
            this.petsRepository = petsRepository;
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

        public IEnumerable<KeyValuePair<string, string>> GetAllPetsAsKeyValuePairs()
        {
            return this.petsRepository.AllAsNoTracking().Select(p => new
            {
                p.Id,
                p.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 9)
        {
            var pets = this.petsRepository.AllAsNoTracking()
                .OrderByDescending(p => p.CreatedOn)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return pets;
        }

        public int GetPetsCount()
        {
            return this.petsRepository.AllAsNoTracking().Count();
        }

        public T GetById<T>(int id)
        {
            var pet = this.petsRepository.AllAsNoTracking()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefault();
            return pet;
        }
    }
}
