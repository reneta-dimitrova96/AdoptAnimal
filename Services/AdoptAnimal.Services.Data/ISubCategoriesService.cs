namespace AdoptAnimal.Services.Data
{
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.SubCategories;

    public interface ISubCategoriesService
    {
        Task CreateAsync(CreateSubCategoryInputModel input);
    }
}
