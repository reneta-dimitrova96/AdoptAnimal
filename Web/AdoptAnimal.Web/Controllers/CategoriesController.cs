namespace AdoptAnimal.Web.Controllers
{
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateCategoryInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoriesService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult GetAllCategories()
        {
            var viewModel = categoriesService.GetAllCategories();
            return this.View(viewModel);
        }
    }
}
