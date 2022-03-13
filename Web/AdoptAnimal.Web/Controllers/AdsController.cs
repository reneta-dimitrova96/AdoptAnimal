namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Ads;
    using Microsoft.AspNetCore.Mvc;

    public class AdsController : Controller
    {
        private readonly IAdService adsService;

        public AdsController(IAdService adsService)
        {
            this.adsService = adsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAdInputModel();
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
