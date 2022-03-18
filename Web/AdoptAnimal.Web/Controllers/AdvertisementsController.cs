namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Ads;
    using Microsoft.AspNetCore.Mvc;

    public class AdvertisementsController : Controller
    {
        private readonly IAdvertisementService adsService;
        private readonly IPetsService petsService;

        public AdvertisementsController(IAdvertisementService adsService, IPetsService petsService)
        {
            this.adsService = adsService;
            this.petsService = petsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAdvertisementInputModel();
            viewModel.PetsItems = this.petsService.GetAllPetsAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertisementInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.adsService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult GetAllAdvertisements()
        {
            var viewModel = this.adsService.GetAllAdvertisements();
            return this.View(viewModel);
        }
    }
}
