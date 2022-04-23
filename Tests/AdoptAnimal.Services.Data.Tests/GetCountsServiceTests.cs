namespace AdoptAnimal.Services.Data.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using Xunit;

    public class GetCountsServiceTests : BaseServiceTests
    {
        private IGetCountsService Service => this.ServiceProvider.GetRequiredService<IGetCountsService>();

        [Fact]
        public void GetCountsShouldReturnCorrectResult()
        {
            var actualResult = this.Service.GetCounts();
            Assert.Equal(1, actualResult.AdsCount);
            Assert.Equal(1, actualResult.UsersCount);
            Assert.Equal(1, actualResult.CategoriesCount);
            Assert.Equal(0, actualResult.AdoptAnimalsCount);
        }
    }
}
