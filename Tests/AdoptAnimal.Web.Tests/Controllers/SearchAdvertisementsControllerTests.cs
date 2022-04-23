namespace AdoptAnimal.Web.Tests.Controllers
{
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.SearchAdvertisements;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using Xunit;

    public class SearchAdvertisementsControllerTests
    {
        private Mock<ICategoriesService> mockCategoriesService;
        private Mock<IAdvertisementsService> mockAdsService;

        public SearchAdvertisementsControllerTests()
        {
            this.mockCategoriesService = new Mock<ICategoriesService>();
            this.mockAdsService = new Mock<IAdvertisementsService>();
        }

        [Fact]
        public void IndexShouldReturnCorrectViewModel()
        {
            this.mockCategoriesService.Setup(a => a.GetAllCategories<CategoryNameIdViewModel>())
              .Returns(new List<CategoryNameIdViewModel>())
              .Verifiable();

            var controller = new SearchAdvertisementsController(
                 this.mockAdsService.Object,
                 this.mockCategoriesService.Object);

            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.Index() as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.SearchAdvertisements.SearchIndexViewModel");
        }

        [Fact]
        public void ListShouldReturnCorrectView()
        {
            var model = new SearchListInputModel()
            {
                CategoryId = 1,
            };

            this.mockAdsService.Setup(a => a.GetByCategory<AdvertisementInListViewModel>(1))
              .Returns(new List<AdvertisementInListViewModel>())
              .Verifiable();

            var controller = new SearchAdvertisementsController(
                 this.mockAdsService.Object,
                 this.mockCategoriesService.Object);

            var result = controller.List(model);
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.List(model) as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.SearchAdvertisements.ListViewModel");
        }
    }
}
