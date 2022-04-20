namespace AdoptAnimal.Web.Controllers
{
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IAdvertisementsService adsService;

        public HomeController(
            IGetCountsService countsService,
            IAdvertisementsService adsService)
        {
            this.countsService = countsService;
            this.adsService = adsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.countsService.GetCounts();
            viewModel.RecentAdvertisements = this.adsService.GetRecentAdvertisements<AdvertisementInListViewModel>();
            return this.View(viewModel);
        }
    }
}
