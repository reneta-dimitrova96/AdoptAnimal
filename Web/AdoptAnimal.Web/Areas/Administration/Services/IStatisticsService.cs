namespace AdoptAnimal.Web.Areas.Administration.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    public interface IStatisticsService
    {
        Task CreateAsync(DateTime startDate, DateTime endDate);

        IEnumerable<Statistic> GetAllStatistics();

        Statistic GetById(int id);
    }
}
