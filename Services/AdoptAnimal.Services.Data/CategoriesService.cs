namespace AdoptAnimal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Web.ViewModels.Categories;
    using AdoptAnimal.Web.ViewModels.SubCategories;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<SubCategory> subCategoriesRepository;

        public CategoriesService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<SubCategory> subCategoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.subCategoriesRepository = subCategoriesRepository;
        }

        public async Task CreateAsync(CreateCategoryInputModel input)
        {
            var category = new Category
            {
                Name = input.Name,
            };
            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoriesRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public GetAllCategoriesInputModel GetAllCategories()
        {
            var data = new GetAllCategoriesInputModel
            {
                Categories = this.categoriesRepository.AllAsNoTracking().Select(c => new GetGategoryInputModel
                {
                    Name = c.Name,
                    CountOfPets = c.Pets.Count,
                    SubCategories = this.subCategoriesRepository.AllAsNoTracking().Where(sc => sc.CategoryId == c.Id).Select(sc => new GetSubGategoryInputModel
                    {
                        Name = sc.Name,
                    }).ToList(),
                }).ToList(),
            };
            return data;
        }
    }
}
