namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Categories;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Mvc;

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

        public IActionResult All()
        {
            var viewModel = new GetAllCategoriesViewModel
            {
                Categories = this.categoriesService.GetAllCategories<GetGategoryViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var category = this.categoriesService.GetById<CategoryPetsViewModel>(id);
            return this.View(category);
        }
    }
}
