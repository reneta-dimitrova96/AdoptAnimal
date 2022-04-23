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

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 9;
            var viewModel = new PetsListViewModel
            {
                Pets = this.petsService.GatAllPets<PetInListViewModel>(id, ItemsPerPage),
                PageNumber = id,
                EntityCount = this.petsService.GetPetsCount(),
                ItemsPerPage = ItemsPerPage,
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var pet = this.petsService.GetById<PetDetailsViewModel>(id);
            if (pet != null)
            {
                return this.View(pet);
            }

            return this.Redirect("/");
        }
    }
}
