namespace AdoptAnimal.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data;
    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Web.Areas.Administration.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class StatisticsController : Controller
    {
        private readonly IDeletableEntityRepository<Statistic> statisticsRepository;
        private readonly IStatisticsService statisticsService;

        public StatisticsController(
            IDeletableEntityRepository<Statistic> statisticsRepository,
            IStatisticsService statisticsService)
        {
            this.statisticsRepository = statisticsRepository;
            this.statisticsService = statisticsService;
        }

        // GET: Administration/Statistics
        public IActionResult Index()
        {
            var statistics = this.statisticsService.GetAllStatistics();
            return this.View(statistics);
        }

        // GET: Administration/Statistics/Details/5
        public IActionResult Details(int id)
        {
            var statistic = this.statisticsService.GetById(id);
            if (statistic == null)
            {
                return this.NotFound();
            }
            return this.View(statistic);
        }

        // GET: Administration/Statistics/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Statistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DateTime startDate, DateTime endDate)
        {
            if (this.ModelState.IsValid)
            {
                await this.statisticsService.CreateAsync(startDate, endDate);
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View();
        }

        // GET: Administration/Statistics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var statistic = await this.statisticsRepository.All()
                .FirstOrDefaultAsync(s => s.Id == id);
            if (statistic == null)
            {
                return this.NotFound();
            }

            return this.View(statistic);
        }

        // POST: Administration/Statistics/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statistic = this.statisticsRepository.All().FirstOrDefault(s => s.Id == id);
            this.statisticsRepository.Delete(statistic);
            await this.statisticsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool StatisticExists(int id)
        {
            return this.statisticsRepository.All().Any(s => s.Id == id);
        }
    }
}
