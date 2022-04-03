namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AdvertisementsController : Controller
    {
        private readonly IAdvertisementService adsService;
        private readonly IPetsService petsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdvertisementsController(
            IAdvertisementService adsService,
            IPetsService petsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager
            )
        {
            this.adsService = adsService;
            this.petsService = petsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateAdvertisementInputModel();
            viewModel.Pet = new CreatePetInputModel();
            viewModel.Pet.GenderTypes = this.petsService.GetAllGenderTypes();
            viewModel.Pet.IsDewormed = this.petsService.GetAllIsDewormedEnumNames();
            viewModel.Pet.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAdvertisementInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Pet = new CreatePetInputModel();
                input.Pet.GenderTypes = this.petsService.GetAllGenderTypes();
                input.Pet.IsDewormed = this.petsService.GetAllIsDewormedEnumNames();
                input.Pet.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.adsService.CreateAsync(input, user.Id);

            return this.Redirect("/");
        }

        public IActionResult GetAllAdvertisements()
        {
            var viewModel = this.adsService.GetAllAdvertisements();
            return this.View(viewModel);
        }
    }
}
