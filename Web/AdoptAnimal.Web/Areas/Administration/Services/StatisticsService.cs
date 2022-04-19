namespace AdoptAnimal.Web.Areas.Administration.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class StatisticsService : IStatisticsService
    {
        private readonly IDeletableEntityRepository<Statistic> statisticsRepository;
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Pet> petsRepository;
        private readonly IDeletableEntityRepository<Advertisement> advertisementsRepository;

        public StatisticsService(
            IDeletableEntityRepository<Statistic> statisticsRepository,
            IDeletableEntityRepository<Article> articlesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Pet> petsRepository,
            IDeletableEntityRepository<Advertisement> advertisementsRepository)
        {
            this.statisticsRepository = statisticsRepository;
            this.articlesRepository = articlesRepository;
            this.usersRepository = usersRepository;
            this.petsRepository = petsRepository;
            this.advertisementsRepository = advertisementsRepository;
        }

        public async Task CreateAsync(DateTime startDate, DateTime endDate)
        {
            var difference = (endDate - startDate).TotalDays;

            var articlesCount = this.articlesRepository.All()
                .Where(ar => ar.CreatedOn > startDate && ar.CreatedOn < endDate)
                .Count();
            var usersCount = this.usersRepository.All()
                .Where(u => u.CreatedOn > startDate && u.CreatedOn < endDate)
                .Count();
            var petsCount = this.petsRepository.All()
                .Where(p => p.CreatedOn > startDate && p.CreatedOn < endDate)
                .Count();
            var advertisementsCount = this.advertisementsRepository.All()
                .Where(a => a.CreatedOn > startDate && a.CreatedOn < endDate)
                .Count();
            var statistic = new Statistic
            {
                StartDate = startDate,
                EndDate = endDate,
                ArticlesCounts = articlesCount,
                UsersCounts = usersCount,
                PetsCount = petsCount,
                AdvertisementsCount = advertisementsCount,
            };
            await this.statisticsRepository.AddAsync(statistic);
            await this.statisticsRepository.SaveChangesAsync();
        }

        public IEnumerable<Statistic> GetAllStatistics()
        {
            var statistics = this.statisticsRepository.AllWithDeleted()
                .ToList();
            return statistics;
        }

        public Statistic GetById(int id)
        {
            var statistic = this.statisticsRepository.AllAsNoTracking()
                .Where(s => s.Id == id)
                .FirstOrDefault();
            return statistic;
        }
    }
}
