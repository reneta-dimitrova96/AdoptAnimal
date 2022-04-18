namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
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

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 6;
            var viewModel = new GetAllArticlesViewModel
            {
                Articles = this.articlesService.GetAllArticles<GetArticleViewModel>(id, ItemsPerPage),
                PageNumber = id,
                EntityCount = this.articlesService.GetArticlesCount(),
                ItemsPerPage = ItemsPerPage,
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var advertisement = this.articlesService.GetById<SingleArticleViewModel>(id);
            return this.View(advertisement);
        }
    }
}
