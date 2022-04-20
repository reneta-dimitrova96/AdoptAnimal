namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoriesRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAllCategories<T>()
        {
            var categories = this.categoriesRepository.AllAsNoTracking()
                .OrderByDescending(c => c.Id)
                .To<T>()
                .ToList();
            return categories;
        }

        public T GetById<T>(int id)
        {
            var category = this.categoriesRepository.AllAsNoTracking()
                .Where(c => c.Id == id)
                .To<T>()
                .FirstOrDefault();
            return category;
        }
    }
}
