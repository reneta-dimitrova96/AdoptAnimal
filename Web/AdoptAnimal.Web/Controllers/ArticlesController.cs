namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(
            IArticlesService articlesService,
            UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.userManager = userManager;
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
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.articlesService.CreateAsync(input, user.Id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 6;
            var viewModel = new ArticlesListViewModel
            {
                Articles = this.articlesService.GetAllArticles<ArticleInListViewModel>(id, ItemsPerPage),
                PageNumber = id,
                EntityCount = this.articlesService.GetArticlesCount(),
                ItemsPerPage = ItemsPerPage,
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var article = this.articlesService.GetById<SingleArticleViewModel>(id);
            if (article != null)
            {
                return this.View(article);
            }

            return this.RedirectToAction("NotFoundError", "Error");
        }
    }
}
