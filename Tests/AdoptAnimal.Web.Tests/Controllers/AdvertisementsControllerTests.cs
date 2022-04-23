namespace AdoptAnimal.Web.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.Comments;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NSubstitute;
    using Xunit;

    public class AdvertisementsControllerTests
    {
        private Mock<IAdvertisementsService> mockAdsService;
        private Mock<IPetsService> mockPetsService;
        private Mock<ICategoriesService> mockCategoriesService;
        private Mock<IWebHostEnvironment> mockWebHostEnvironment;
        private UserManager<ApplicationUser> mockUserManager;

        public AdvertisementsControllerTests()
        {
            this.mockAdsService = new Mock<IAdvertisementsService>();
            this.mockPetsService = new Mock<IPetsService>();
            this.mockCategoriesService = new Mock<ICategoriesService>();
            this.mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            this.mockUserManager = MockUserManager.Create();
        }

        [Fact]
        public void CreateShouldReturnCorrectViewModel()
        {
            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = controller.Create();
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.Create() as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Ads.CreateAdvertisementInputModel");
        }

        [Fact]
        public async Task CreatePostShouldreturnViewIfHaveModelError()
        {
            var model = new CreateAdvertisementInputModel()
            {
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                Pet = new CreatePetInputModel()
                {
                    Name = "Test pet name",
                    Age = 2,
                    Weight = 2,
                    Breed = "test breed",
                    CategoryId = 1,
                    Images = new List<IFormFile>(),
                },
            };

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            controller.ModelState.AddModelError("Title", "Required");

            var result = await controller.Create(model) as ViewResult;

            Assert.IsType<ViewResult>(result);
            Assert.True(result.Model.ToString() == "AdoptAnimal.Web.ViewModels.Ads.CreateAdvertisementInputModel");
        }

        [Fact]
        public async Task CreatePostWithValidDataShouldRedirectToAllAds()
        {
            var model = new CreateAdvertisementInputModel()
            {
                Title = "Test ad",
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                Pet = new CreatePetInputModel()
                {
                    Name = "Test pet name",
                    Age = 2,
                    Weight = 2,
                    Breed = "test breed",
                    CategoryId = 1,
                    Images = new List<IFormFile>(),
                },
            };

            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            this.mockUserManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
                .Returns(Task.FromResult<ApplicationUser>(appUser));

            this.mockAdsService.Setup(a => a.CreateAsync(model, appUser.Id, "wwwroot/images"))
              .Returns(Task.CompletedTask)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = await controller.Create(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("All", redirectToActionResult.ActionName);
        }

        [Fact]
        public void UpdateShouldReturnCorrectViewModel()
        {
            var model = new EditAdvertisementInputModel()
            {
                Id = 1,
                Title = "Test ad",
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                PetIsAdopted = true,
            };

            this.mockAdsService.Setup(a => a.GetById<EditAdvertisementInputModel>(1))
              .Returns(model)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = controller.Edit(1);
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.Edit(1) as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Advertisements.EditAdvertisementInputModel");
        }

        [Fact]
        public async Task UpdatePostShouldreturnViewIfHaveModelError()
        {
            var model = new EditAdvertisementInputModel()
            {
                Id = 1,
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                PetIsAdopted = true,
            };

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            controller.ModelState.AddModelError("Title", "Required");

            var result = await controller.Edit(1, model) as ViewResult;

            Assert.IsType<ViewResult>(result);
            Assert.True(result.Model.ToString() == "AdoptAnimal.Web.ViewModels.Advertisements.EditAdvertisementInputModel");
        }

        [Fact]
        public async Task UpdateShouldRedirectToById()
        {
            var model = new EditAdvertisementInputModel()
            {
                Id = 1,
                Title = "Test ad",
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                PetIsAdopted = true,
            };

            this.mockAdsService.Setup(a => a.UpdateAsync(1, model))
              .Returns(Task.CompletedTask)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = await controller.Edit(1, model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("ById", redirectToActionResult.ActionName);
        }

        [Fact]
        public void ByIdShouldReturnCorrectAdvertisement()
        {
            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            var singleAdViewModel = new SingleAdvertisementViewModel
            {
                Id = 1,
                Title = "Test ad",
                CreatedOn = new DateTime(2022, 3, 1, 8, 30, 52),
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                AuthorUserName = appUser.UserName,
                Pet = new PetDetailsViewModel
                {
                    Name = "Test pet name",
                    Age = 2,
                    Gender = "female",
                    Weight = 2,
                    Breed = "test breed",
                    IsDewormed = "yes",
                    IsAdopted = true,
                    AdvertisementId = 1,
                    CategoryName = "test category name",
                    PetImages = new List<PetImageViewModel>
                    {
                        new PetImageViewModel
                        {
                           Id = "test image string id",
                           ImageUrl = "test image url",
                        },
                    },
                },
                Comments = new List<CommentInListViewModel>
                {
                    new CommentInListViewModel
                    {
                        Content = "Test Comment content",
                        AuthorUserName = appUser.UserName,
                        CreatedOn = new DateTime(2022, 3, 1, 8, 30, 52),
                    },
                },
            };

            this.mockAdsService.Setup(a => a.GetById<SingleAdvertisementViewModel>(1))
              .Returns(singleAdViewModel)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = controller.ById(1);
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.ById(1) as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Advertisements.SingleAdvertisementViewModel");
        }

        [Fact]
        public void ByIdShouldRedirectIfAdIsNull()
        {
            this.mockAdsService.Setup(a => a.GetById<SingleAdvertisementViewModel>(1))
                               .Returns(value: null)
                               .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = controller.ById(1);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void AllShouldReturnCorrectView()
        {
            this.mockAdsService.Setup(a => a.GetAllAdvertisements<AdvertisementInListViewModel>(1, 12))
              .Returns(new List<AdvertisementInListViewModel>())
              .Verifiable();

            this.mockAdsService.Setup(a => a.GetAdsCount())
              .Returns(10)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = controller.All();
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.All() as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Advertisements.AdvertisementsListViewModel");
        }

        [Fact]
        public async Task DeleteShouldRedirectToNotFoundErrorPageIdUserIsNotAuthorOfAd()
        {
            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            this.mockUserManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
                .Returns(Task.FromResult<ApplicationUser>(appUser));

            this.mockAdsService.Setup(a => a.IsAuthorOfAd(1, appUser.Id))
              .Returns(false)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = await controller.Delete(1);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task DeleteWithValidDataShouldRedirectToMyAds()
        {
            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            this.mockUserManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
                .Returns(Task.FromResult<ApplicationUser>(appUser));

            this.mockAdsService.Setup(a => a.IsAuthorOfAd(1, appUser.Id))
              .Returns(true)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = await controller.Delete(1);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("AdsByUserId", redirectToActionResult.ActionName);
        }

        [Fact]
        public void AdsByUserIdShouldReturnCorrectView()
        {
            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            this.mockUserManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
                .Returns(Task.FromResult<ApplicationUser>(appUser));

            this.mockAdsService.Setup(a => a.GetByUserId<AdvertisementInListViewModel>(appUser.Id))
              .Returns(new List<AdvertisementInListViewModel>())
              .Verifiable();

            this.mockAdsService.Setup(a => a.GetAdsCount())
              .Returns(10)
              .Verifiable();

            var controller = new AdvertisementsController(
                this.mockAdsService.Object,
                this.mockPetsService.Object,
                this.mockCategoriesService.Object,
                this.mockUserManager,
                this.mockWebHostEnvironment.Object);

            var result = controller.AdsByUserId();
            Assert.IsType<ViewResult>(result);
        }
    }
}
