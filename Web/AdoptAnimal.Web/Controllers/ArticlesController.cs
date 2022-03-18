﻿namespace AdoptAnimal.Web.Controllers
{
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.articlesService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult GetAllArticles()
        {
            var viewModel = this.articlesService.GetAllArticles();
            return this.View(viewModel);
        }
    }
}