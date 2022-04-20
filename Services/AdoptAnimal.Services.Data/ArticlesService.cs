namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Articles;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task CreateAsync(CreateArticleInputModel input, string userId)
        {
            var article = new Article
            {
                Title = input.Title,
                Content = input.Content,
                AuthorId = userId,
                Source = input.Source,
                ImageUrl = input.ImageUrl,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllArticles<T>(int page, int itemsPerPage = 6)
        {
            var articles = this.articlesRepository.AllAsNoTracking()
                .OrderByDescending(a => a.CreatedOn)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return articles;
        }

        public int GetArticlesCount()
        {
            return this.articlesRepository.AllAsNoTracking().Count();
        }

        public T GetById<T>(int id)
        {
            var article = this.articlesRepository.AllAsNoTracking()
                .Where(a => a.Id == id)
                .To<T>()
                .FirstOrDefault();
            return article;
        }
    }
}
