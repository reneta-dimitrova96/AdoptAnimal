namespace AdoptAnimal.Services.Data.Tests
{
    using System.Linq;

    using AdoptAnimal.Web.ViewModels.Categories;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CategoriesServiceTests : BaseServiceTests
    {
        private string userId;
        private int adId;
        private int categoryId;

        public CategoriesServiceTests()
        {
            this.userId = this.DbContext.Users.Select(u => u.Id).First();
            this.adId = this.DbContext.Advertisements.FirstOrDefault().Id;
            this.categoryId = this.DbContext.Categories.FirstOrDefault().Id;
        }

        private ICategoriesService Service => this.ServiceProvider.GetRequiredService<ICategoriesService>();

        [Fact]
        public void GetAllCategories()
        {
            var categories = this.Service.GetAllCategories<CategoryInListViewModel>();
            Assert.Single(categories);
        }

        [Fact]
        public void GetAllCategoriesAsKeyValuePair()
        {
            var categories = this.Service.GetAllAsKeyValuePairs();
            Assert.Single(categories);
            Assert.Equal("1", categories.First().Key);
            Assert.Equal("Test category name", categories.First().Value);
        }

        [Fact]
        public void GetByIdReturnsCorrectRecord()
        {
            var category = this.Service.GetById<CategoryPetsViewModel>(this.categoryId);
            Assert.Equal("Test category name", category.Name);
        }

        [Fact]
        public void GetByIdReturnsShouldReturnNullIfIdIsInvalid()
        {
            var actualResult = this.Service.GetById<CategoryPetsViewModel>(0);
            Assert.Null(actualResult);
        }
    }
}
