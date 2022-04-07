namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleInputModel input);

        IEnumerable<T> GetAllArticles<T>(int page, int itemsPerPage = 6);

        int GetArticlesCount();

        T GetById<T>(int id);
    }
}
