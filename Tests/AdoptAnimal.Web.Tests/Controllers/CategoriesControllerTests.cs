namespace AdoptAnimal.Web.Tests.Controllers
{
    using System;
    using System.Collections.Generic;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Categories;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class CategoriesControllerTests
    {
        private Mock<ICategoriesService> mockCategoriesService;

        public CategoriesControllerTests()
        {
            this.mockCategoriesService = new Mock<ICategoriesService>();
        }

        [Fact]
        public void AllShouldReturnCorrectView()
        {
            this.mockCategoriesService.Setup(a => a.GetAllCategories<CategoryInListViewModel>())
              .Returns(new List<CategoryInListViewModel>())
              .Verifiable();

            var controller = new CategoriesController(
                this.mockCategoriesService.Object);

            var result = controller.All();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ByIdShouldReturnCorrectCategoryWithPets()
        {
            var categoryWithPetViewModel = new CategoryPetsViewModel
            {
                Name = "test category name",
                Pets = new List<PetInListViewModel>
                {
                    new PetInListViewModel
                    {
                        Id = 1,
                        Name = "Test pet name",
                        CreatedOn = new DateTime(2022, 3, 1, 8, 30, 52),
                        CategoryName = "test category name",
                        ImageUrl = "test image url",
                    },
                },
            };

            this.mockCategoriesService.Setup(a => a.GetById<CategoryPetsViewModel>(1))
              .Returns(categoryWithPetViewModel)
              .Verifiable();

            var controller = new CategoriesController(
               this.mockCategoriesService.Object);

            var result = controller.ById(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ByIdShouldRedirectIfCategoryIsNull()
        {
            this.mockCategoriesService.Setup(a => a.GetById<CategoryPetsViewModel>(1))
             .Returns(value: null)
             .Verifiable();

            var controller = new CategoriesController(
               this.mockCategoriesService.Object);

            var result = controller.ById(1);
            Assert.IsType<RedirectResult>(result);
        }
    }
}
