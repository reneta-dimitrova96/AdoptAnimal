namespace AdoptAnimal.Web.Controllers
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
                input.GenderTypes = this.petsService.GetAllGenderTypes();
                input.IsDewormed = this.petsService.GetAllIsDewormedEnumNames();
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var petId = await this.petsService.CreateAsync(input);

            return this.Redirect($"/Advertisements/Create/{petId}");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 9;
            var viewModel = new PetsListViewModel
            {
                Pets = this.petsService.GetAll<PetInListViewModel>(id, ItemsPerPage),
                PageNumber = id,
                EntityCount = this.petsService.GetPetsCount(),
                ItemsPerPage = ItemsPerPage,
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var pet = this.petsService.GetById<PetDetailsViewModel>(id);
            return this.View(pet);
        }
    }
}
