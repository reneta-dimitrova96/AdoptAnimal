namespace AdoptAnimal.Services.Data
{
    using AdoptAnimal.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        IndexViewModel GetCounts();
    }
}
