namespace AdoptAnimal.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AdvertisementsController : Controller
    {
        private readonly IAdvertisementService adsService;
        private readonly IPetsService petsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public AdvertisementsController(
            IAdvertisementService adsService,
            IPetsService petsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.adsService = adsService;
            this.petsService = petsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateAdvertisementInputModel();
            viewModel.Pet = new CreatePetInputModel
            {
                GenderTypes = this.petsService.GetAllGenderTypes(),
                IsDewormed = this.petsService.GetAllIsDewormedEnumNames(),
                CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAdvertisementInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Pet = new CreatePetInputModel
                {
                    GenderTypes = this.petsService.GetAllGenderTypes(),
                    IsDewormed = this.petsService.GetAllIsDewormedEnumNames(),
                    CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs(),
                };
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.adsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception error)
            {
                this.ModelState.AddModelError(string.Empty, error.Message);
                input.Pet = new CreatePetInputModel();
                input.Pet.GenderTypes = this.petsService.GetAllGenderTypes();
                input.Pet.IsDewormed = this.petsService.GetAllIsDewormedEnumNames();
                input.Pet.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var viewModel = new AdvertisementsListViewModel
            {
                Advertisements = this.adsService.GetAll<AdvertisementInListViewModel>(id, ItemsPerPage),
                PageNumber = id,
                EntityCount = this.adsService.GetAdsCount(),
                ItemsPerPage = ItemsPerPage,
            };
            return this.View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var inputModel = this.adsService.GetById<EditAdvertisementInputModel>(id);
            inputModel.Id = id;
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditAdvertisementInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Id = id;
                return this.View();
            }

            await this.adsService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        public IActionResult ById(int id)
        {
            var advertisement = this.adsService.GetById<SingleAdvertisementViewModel>(id);
            return this.View(advertisement);
        }
    }
}
