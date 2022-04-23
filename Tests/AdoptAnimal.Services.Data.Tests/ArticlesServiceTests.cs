namespace AdoptAnimal.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Articles;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class ArticlesServiceTests : BaseServiceTests
    {
        private string userId;
        public int articleId;

        public ArticlesServiceTests()
        {
            this.userId = this.DbContext.Users.Select(u => u.Id).First();
            this.articleId = this.DbContext.Articles.Select(a => a.Id).First();
        }

        private IArticlesService Service => this.ServiceProvider.GetRequiredService<IArticlesService>();

        [Fact]
        public async Task CreateArticleAsyncWithCorrectData()
        {
            var inputModel = new CreateArticleInputModel
            {
                Title = "Test article name 2",
                Content = "Test article content 2 is here",
                Source = "https://softuni.bg/",
                ImageUrl = "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/322868_1100-800x825.jpg",
            };

            await this.Service.CreateAsync(inputModel, this.userId);
            Assert.Equal(2, this.DbContext.Articles.Count());
        }

        [Fact]
        public async Task CreateArticleAsyncWithEmptyNonRequiredFields()
        {
            var inputModel = new CreateArticleInputModel
            {
                Title = "Test article name 3",
                Content = "Test article content 3 is here",
            };

            await this.Service.CreateAsync(inputModel, this.userId);
            Assert.Equal(2, this.DbContext.Articles.Count());

            var article = this.DbContext.Articles.Where(a => a.Title == "Test article name 3").First();
            Assert.True(article != null);
        }

        [Fact]
        public void GetAllArticlesShouldReturnCorrectResult()
        {
            var articles = this.Service.GetAllArticles<ArticleInListViewModel>(1, 6);
            Assert.Single(articles);
        }

        [Fact]

        public void GetArticlesCountShouldReturnCorrectNumber()
        {
            var articlesCount = this.Service.GetArticlesCount();
            Assert.Equal(1, articlesCount);
        }

        [Fact]
        public void GetByIdReturnsCorrectRecord()
        {
            var article = this.Service.GetById<SingleArticleViewModel>(this.articleId);
            Assert.Equal("Test article name", article.Title);
        }

        [Fact]
        public void GetByIdReturnsShouldReturnNullIfIdIsInvalid()
        {
            var actualResult = this.Service.GetById<SingleArticleViewModel>(0);
            Assert.Null(actualResult);
        }
    }
}
