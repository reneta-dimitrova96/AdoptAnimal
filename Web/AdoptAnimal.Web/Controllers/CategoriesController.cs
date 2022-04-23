namespace AdoptAnimal.Web.Controllers
{
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

        public IActionResult All()
        {
            var viewModel = new CategoriesListViewModel
            {
                Categories = this.categoriesService.GetAllCategories<CategoryInListViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var category = this.categoriesService.GetById<CategoryPetsViewModel>(id);
            if (category != null)
            {
                return this.View(category);
            }

            return this.RedirectToAction("NotFoundError", "Error");
        }
    }
}
