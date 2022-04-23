using AdoptAnimal.Web.ViewModels.Comments;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdoptAnimal.Services.Data.Tests
{
    public class CommentsServiceTests : BaseServiceTests
    {
        private string userId;
        private int adId;

        public CommentsServiceTests()
        {
            this.userId = this.DbContext.Users.Select(u => u.Id).First();
            this.adId = this.DbContext.Advertisements.FirstOrDefault().Id;
        }

        private ICommentsService Service => this.ServiceProvider.GetRequiredService<ICommentsService>();

        [Fact]
        public async Task CreateCommentAsyncWithCorrectData()
        {
            var inputModel = new CreateCommentInputModel
            {
                Content = "Test Comment content 2",
                AdvertisementId = this.adId,
            };

            await this.Service.CreateAsync(inputModel, this.userId);
            Assert.Equal(2, this.DbContext.Comments.Count());
        }

        [Fact]
        public void GetAllCommentsByAdIdShouldReturnCorrectResult()
        {
            var comments = this.Service.GetAllCommentsByAdId<CommentInListViewModel>(this.adId);
            Assert.Single(comments);
        }

        [Fact]
        public void GetAllCommentsByAdIdShouldReturnEmptyListIfAdIdIsInvalid()
        {
            var actualResult = this.Service.GetAllCommentsByAdId<CommentInListViewModel>(0);
            Assert.Empty(actualResult);
        }

        [Fact]
        public void GetCommentsCountShouldReturnCorrectNumber()
        {
            var commentsCount = this.Service.GetCommentsCount();
            Assert.Equal(1, commentsCount);
        }
    }
}
