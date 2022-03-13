namespace AdoptAnimal.Services.Data
{
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;

    public interface IAdService
    {
        Task CreateAsync(CreateAdInputModel input);
    }
}
