namespace AdoptAnimal.Web.Tests.Controllers
{
    using System.Collections.Generic;

    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class HomeControllerTests
    {
        private Mock<IGetCountsService> mockGetCountsService;
        private Mock<IAdvertisementsService> mockAdsService;

        public HomeControllerTests()
        {
            this.mockGetCountsService = new Mock<IGetCountsService>();
            this.mockAdsService = new Mock<IAdvertisementsService>();
        }

        [Fact]
        public void IndexShouldReturnCorrectViewModel()
        {
            this.mockGetCountsService.Setup(a => a.GetCounts())
              .Returns(new IndexViewModel())
              .Verifiable();

            this.mockAdsService.Setup(a => a.GetRecentAdvertisements<AdvertisementInListViewModel>())
              .Returns(new List<AdvertisementInListViewModel>())
              .Verifiable();

            var controller = new HomeController(
                this.mockGetCountsService.Object,
                this.mockAdsService.Object);

            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
