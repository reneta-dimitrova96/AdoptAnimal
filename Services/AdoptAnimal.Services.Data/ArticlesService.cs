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

        public async Task CreateAsync(CreateArticleInputModel input)
        {
            var article = new Article
            {
                Title = input.Title,
                Content = input.Content,
            };
            article.ArticleImages.Add(new ArticleImage
            {
                Source = input.ArticleImageSorce,
            });

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
    }
}
