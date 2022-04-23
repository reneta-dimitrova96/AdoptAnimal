using AdoptAnimal.Web.ViewModels.Pets;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace AdoptAnimal.Services.Data.Tests
{
    public class PetsServiceTests : BaseServiceTests
    {
        private string userId;
        private int adId;
        private int categoryId;

        public PetsServiceTests()
        {
            this.userId = this.DbContext.Users.Select(u => u.Id).First();
            this.adId = this.DbContext.Advertisements.FirstOrDefault().Id;
            this.categoryId = this.DbContext.Categories.FirstOrDefault().Id;
        }

        private IPetsService Service => this.ServiceProvider.GetRequiredService<IPetsService>();

        [Fact]
        public void GetAllGenderTypesShouldReturnCorrectResult()
        {
            var genderTypes = this.Service.GetAllGenderTypes();
            Assert.Equal(2, genderTypes.Count());
            Assert.Equal(1, genderTypes.First().Key);
            Assert.Equal("Male", genderTypes.First().Value);
        }

        [Fact]
        public void GetAllIsDewormedEnumNamesShouldReturnCorrectResult()
        {
            var isDewormedTypes = this.Service.GetAllIsDewormedEnumNames();
            Assert.Equal(3, isDewormedTypes.Count());
            Assert.Equal(1, isDewormedTypes.First().Key);
            Assert.Equal("Yes", isDewormedTypes.First().Value);
        }

        [Fact]
        public void GetAllPetsAsKeyValuePairShouldReturnCorrectResult()
        {
            var pets = this.Service.GetAllPetsAsKeyValuePairs();
            Assert.Single(pets);
            Assert.Equal("1", pets.First().Key);
            Assert.Equal("Test pet name", pets.First().Value);
        }

        [Fact]
        public void GetAllPetsShouldReturnCorrectResult()
        {
            var pets = this.Service.GatAllPets<PetInListViewModel>(1, 9);
            Assert.Single(pets);
        }

        [Fact]
        public void GetPetsCountShouldReturnCorrectNumber()
        {
            var petsCount = this.Service.GetPetsCount();
            Assert.Equal(1, petsCount);
        }

        [Fact]
        public void GetByIdReturnsCorrectRecord()
        {
            var pet = this.Service.GetById<PetDetailsViewModel>(this.adId);
            Assert.Equal("Test pet name", pet.Name);
        }

        [Fact]
        public void GetByIdReturnsShouldReturnNullIfIdIsInvalid()
        {
            var actualResult = this.Service.GetById<PetDetailsViewModel>(0);
            Assert.Null(actualResult);
        }
    }
}
