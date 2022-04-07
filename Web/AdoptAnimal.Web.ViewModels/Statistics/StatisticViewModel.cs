namespace AdoptAnimal.Web.ViewModels.Statistics
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class StatisticViewModel : IMapFrom<Statistic>
    {
        public int CountOfViews { get; set; }
    }
}
