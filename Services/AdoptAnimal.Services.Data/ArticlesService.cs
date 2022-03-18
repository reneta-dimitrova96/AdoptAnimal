﻿namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
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
            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public GetAllArticlesInputModel GetAllArticles()
        {
            var data = new GetAllArticlesInputModel
            {
                Articles = this.articlesRepository.AllAsNoTracking().Select(a => new GetArticleInputModel
                {
                    Title = a.Title,
                    Content = a.Content,
                }),
            };
            return data;
        }
    }
}