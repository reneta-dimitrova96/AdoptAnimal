namespace AdoptAnimal.Web.Controllers
{
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.SearchAdvertisements;
    using Microsoft.AspNetCore.Mvc;

    public class SearchAdvertisementsController : Controller
    {
        private readonly IAdvertisementService adsService;
        private readonly ICategoriesService categoriesService;

        public SearchAdvertisementsController(
            IAdvertisementService adsService,
            ICategoriesService categoriesService)
        {
            this.adsService = adsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Categories = this.categoriesService.GetAllCategories<CategoryNameIdViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Advertisements = this.adsService.GetByCategory<AdvertisementInListViewModel>(input.CategoryId),
            };

            return this.View(viewModel);
        }
    }
}
