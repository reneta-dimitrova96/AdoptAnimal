namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Ads;
    using Microsoft.AspNetCore.Mvc;

    public class AdsController : Controller
    {
        private readonly IAdService adsService;
        private readonly IPetsService petsService;

        public AdsController(IAdService adsService, IPetsService petsService)
        {
            this.adsService = adsService;
            this.petsService = petsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAdInputModel();
            viewModel.PetsItems = this.petsService.GetAllPetsAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.adsService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
