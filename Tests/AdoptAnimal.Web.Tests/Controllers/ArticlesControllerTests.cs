namespace AdoptAnimal.Web.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NSubstitute;
    using Xunit;

    public class ArticlesControllerTests
    {
        private Mock<IArticlesService> mockArticlesService;
        private UserManager<ApplicationUser> mockUserManager;

        public ArticlesControllerTests()
        {
            this.mockArticlesService = new Mock<IArticlesService>();
            this.mockUserManager = MockUserManager.Create();
        }

        [Fact]
        public void CreateShouldReturnCorrectViewModel()
        {
            var controller = new ArticlesController(
                this.mockArticlesService.Object,
                this.mockUserManager);

            var result = controller.Create();
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.Create() as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Articles.CreateArticleInputModel");
        }

        [Fact]
        public async Task CreatePostShouldreturnViewIfHaveModelError()
        {
            var model = new CreateArticleInputModel()
            {
                Content = "Test article content is here",
                Source = "https://softuni.bg/",
                ImageUrl = "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/322868_1100-800x825.jpg",
            };

            var controller = new ArticlesController(
               this.mockArticlesService.Object,
               this.mockUserManager);

            controller.ModelState.AddModelError("Title", "Required");

            var result = await controller.Create(model) as ViewResult;

            Assert.IsType<ViewResult>(result);
            Assert.True(result.Model.ToString() == "AdoptAnimal.Web.ViewModels.Articles.CreateArticleInputModel");
        }

        [Fact]
        public async Task CreatePostWithValidDataShouldRedirectToAllArticles()
        {
            var model = new CreateArticleInputModel()
            {
                Title = "Test article name",
                Content = "Test article content is here",
                Source = "https://softuni.bg/",
                ImageUrl = "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/322868_1100-800x825.jpg",
            };

            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            this.mockUserManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
                .Returns(Task.FromResult<ApplicationUser>(appUser));

            this.mockArticlesService.Setup(a => a.CreateAsync(model, appUser.Id))
              .Returns(Task.CompletedTask)
              .Verifiable();

            var controller = new ArticlesController(
               this.mockArticlesService.Object,
               this.mockUserManager);

            var result = await controller.Create(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("All", redirectToActionResult.ActionName);
        }

        [Fact]
        public void AllShouldReturnCorrectView()
        {
            this.mockArticlesService.Setup(a => a.GetAllArticles<ArticleInListViewModel>(1, 6))
              .Returns(new List<ArticleInListViewModel>())
              .Verifiable();

            this.mockArticlesService.Setup(a => a.GetArticlesCount())
              .Returns(10)
              .Verifiable();

            var controller = new ArticlesController(
                this.mockArticlesService.Object,
                this.mockUserManager);

            var result = controller.All();
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.All() as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Articles.ArticlesListViewModel");
        }

        [Fact]
        public void ByIdShouldReturnCorrectArticle()
        {
            var singleArticleViewModel = new SingleArticleViewModel
            {
                Title = "Test article name",
                Content = "Test article content is here",
                CreatedOn = new DateTime(2022, 3, 1, 8, 30, 52),
                Source = "https://softuni.bg/",
                ImageUrl = "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/322868_1100-800x825.jpg",
                AuthorUserName = "test username",
            };

            this.mockArticlesService.Setup(a => a.GetById<SingleArticleViewModel>(1))
              .Returns(singleArticleViewModel)
              .Verifiable();

            var controller = new ArticlesController(
                this.mockArticlesService.Object,
                this.mockUserManager);

            var result = controller.ById(1);
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.ById(1) as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Articles.SingleArticleViewModel");
        }

        [Fact]
        public void ByIdShouldRedirectIfArticleIDNull()
        {
            this.mockArticlesService.Setup(a => a.GetById<SingleArticleViewModel>(1))
             .Returns(value: null)
             .Verifiable();

            var controller = new ArticlesController(
                this.mockArticlesService.Object,
                this.mockUserManager);

            var result = controller.ById(1);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
