namespace AdoptAnimal.Services.Data
{
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel input);
    }
}
