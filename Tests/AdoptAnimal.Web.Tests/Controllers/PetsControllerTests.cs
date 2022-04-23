namespace AdoptAnimal.Web.Tests.Controllers
{
    using System.Collections.Generic;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class PetsControllerTests
    {
        private Mock<IPetsService> mockPetsService;
        private Mock<ICategoriesService> mockCategoriesService;

        public PetsControllerTests()
        {
            this.mockPetsService = new Mock<IPetsService>();
            this.mockCategoriesService = new Mock<ICategoriesService>();
        }

        [Fact]
        public void AllShouldReturnCorrectView()
        {
            this.mockPetsService.Setup(a => a.GatAllPets<PetInListViewModel>(1, 9))
              .Returns(new List<PetInListViewModel>())
              .Verifiable();

            var controller = new PetsController(
                this.mockPetsService.Object,
                this.mockCategoriesService.Object);

            var result = controller.All();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ByIdShouldReturnCorrectPet()
        {
            this.mockPetsService.Setup(a => a.GetById<PetDetailsViewModel>(1))
              .Returns(new PetDetailsViewModel())
              .Verifiable();

            var controller = new PetsController(
                this.mockPetsService.Object,
                this.mockCategoriesService.Object);

            var result = controller.ById(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ByIdShouldRedirectIfPetIsNull()
        {
            this.mockPetsService.Setup(a => a.GetById<PetDetailsViewModel>(1))
              .Returns(value: null)
              .Verifiable();

            var controller = new PetsController(
                           this.mockPetsService.Object,
                           this.mockCategoriesService.Object);

            var result = controller.ById(1);
            Assert.IsType<RedirectResult>(result);
        }
    }
}
