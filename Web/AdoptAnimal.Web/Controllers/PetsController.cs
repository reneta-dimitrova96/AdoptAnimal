﻿namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Mvc;

    public class PetsController : Controller
    {
        private readonly IPetsService petsService;
        private readonly ICategoriesService categoriesService;

        public PetsController(IPetsService petsService, ICategoriesService categoriesService)
        {
            this.petsService = petsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePetInputModel();
            viewModel.GenderTypes = this.petsService.GetAllGenderTypes();
            viewModel.IsDewormed = this.petsService.GetAllIsDewormedEnumNames();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePetInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.petsService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult GetAllPets()
        {
            var viewModel = this.petsService.GetAllPets();
            return this.View(viewModel);
        }
    }
}
