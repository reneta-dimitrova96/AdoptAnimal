namespace AdoptAnimal.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.Controllers;
    using AdoptAnimal.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NSubstitute;
    using Xunit;

    public class CommentsControllerTests
    {
        private Mock<ICommentsService> mockCommentsService;
        private UserManager<ApplicationUser> mockUserManager;

        public CommentsControllerTests()
        {
            this.mockCommentsService = new Mock<ICommentsService>();
            this.mockUserManager = MockUserManager.Create();
        }

        [Fact]
        public void CreateShouldReturnCorrectViewModel()
        {
            var controller = new CommentsController(
                this.mockCommentsService.Object,
                this.mockUserManager);

            var result = controller.Create(1);
            Assert.IsType<ViewResult>(result);
            var resultAsViewResult = controller.Create(1) as ViewResult;
            Assert.True(resultAsViewResult.Model.ToString() == "AdoptAnimal.Web.ViewModels.Comments.CreateCommentInputModel");
        }

        [Fact]
        public async Task CreatePostShouldreturnViewIfHaveModelError()
        {
            var model = new CreateCommentInputModel()
            {
                AdvertisementId = 1,
            };

            var controller = new CommentsController(
                 this.mockCommentsService.Object,
                 this.mockUserManager);

            controller.ModelState.AddModelError("Content", "Required");

            var result = await controller.Create(model) as ViewResult;

            Assert.IsType<ViewResult>(result);
            Assert.True(result.Model.ToString() == "AdoptAnimal.Web.ViewModels.Comments.CreateCommentInputModel");
        }

        [Fact]
        public async Task CreatePostWithValidDataShouldRedirectToAllComments()
        {
            var model = new CreateCommentInputModel()
            {
                AdvertisementId = 1,
                Content = "test content",
            };

            var appUser = new ApplicationUser
            {
                Id = "test user Id",
                UserName = "test UserName",
            };

            this.mockUserManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
                .Returns(Task.FromResult<ApplicationUser>(appUser));

            this.mockCommentsService.Setup(a => a.CreateAsync(model, appUser.Id))
              .Returns(Task.CompletedTask)
              .Verifiable();

            var controller = new CommentsController(
                 this.mockCommentsService.Object,
                 this.mockUserManager);

            var result = await controller.Create(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("All", redirectToActionResult.ActionName);
        }

        [Fact]
        public void AllShouldReturnCorrectView()
        {
            this.mockCommentsService.Setup(a => a.GetAllCommentsByAdId<CommentInListViewModel>(1))
              .Returns(new List<CommentInListViewModel>())
              .Verifiable();

            var controller = new CommentsController(
                this.mockCommentsService.Object,
                this.mockUserManager);

            var result = controller.All(1);
            Assert.IsType<ViewResult>(result);
        }
    }
}
