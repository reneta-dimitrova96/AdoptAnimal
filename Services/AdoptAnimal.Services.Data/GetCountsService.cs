namespace AdoptAnimal.Services.Data
{
    using System.Linq;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Advertisement> adsRepository;
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Advertisement> adsRepository,
            IDeletableEntityRepository<Article> articlesRepository,
            IDeletableEntityRepository<Pet> petsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.articlesRepository = articlesRepository;
            this.adsRepository = adsRepository;
            this.petsRepository = petsRepository; 
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                AdsCount = this.adsRepository.All().Count(),
                PetsCount = this.petsRepository.All().Count(),
                ArticlesCount = this.articlesRepository.All().Count(),
            };
            return data;
        }
    }
}
