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
        private readonly IDeletableEntityRepository<Pet> petsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Advertisement> adsRepository,
            IDeletableEntityRepository<Pet> petsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.petsRepository = petsRepository;
            this.adsRepository = adsRepository;
            this.usersRepository = usersRepository;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                CategoriesCount = this.categoriesRepository.AllAsNoTracking().Count(),
                AdsCount = this.adsRepository.AllAsNoTracking().Count(),
                UsersCount = this.usersRepository.AllAsNoTracking().Count(),
                AdoptAnimalsCount = this.petsRepository.AllAsNoTracking()
                .Where(p => p.IsAdopted == true)
                .Count(),
            };
            return data;
        }
    }
}
