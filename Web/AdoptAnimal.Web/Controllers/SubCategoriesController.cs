namespace AdoptAnimal.Web.Controllers
{
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.SubCategories;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoriesService subCaregoriesService;
        private readonly ICategoriesService categoriesService;

        public SubCategoriesController(ISubCategoriesService subCaregoriesService,
            ICategoriesService categoriesService)
        {
            this.subCaregoriesService = subCaregoriesService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateSubCategoryInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateSubCategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.subCaregoriesService.CreateAsync(input);

            return this.Redirect("/");
        }

    }
}
