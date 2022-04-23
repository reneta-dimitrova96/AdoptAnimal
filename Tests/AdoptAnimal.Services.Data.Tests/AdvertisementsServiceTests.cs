namespace AdoptAnimal.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Advertisements;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class AdvertisementsServiceTests : BaseServiceTests
    {
        private const string TestImagePath = "Test.jpg";
        private string userId;
        private int adId;
        private int categoryId;

        public AdvertisementsServiceTests()
        {
            this.userId = this.DbContext.Users.Select(u => u.Id).First();
            this.adId = this.DbContext.Advertisements.FirstOrDefault().Id;
            this.categoryId = this.DbContext.Categories.FirstOrDefault().Id;
        }

        private IAdvertisementsService Service => this.ServiceProvider.GetRequiredService<IAdvertisementsService>();

        [Fact]
        public async Task CreateAdAsyncWithCorrectData()
        {
            var inputModel = new CreateAdvertisementInputModel
            {
                Title = "Test ad 2",
                Description = "Test description is here 2...",
                PhoneNumber = "0876780040",
                Address = "Test address 2",
                Pet = new CreatePetInputModel
                {
                    Name = "Test pet name 2",
                    Age = 2,
                    Weight = 2,
                    Breed = "Test breed 2",
                    CategoryId = 1,
                },
            };

            await this.Service.CreateAsync(inputModel, this.userId, TestImagePath);
            Assert.Equal(2, this.DbContext.Advertisements.Count());
        }

        [Fact]
        public async Task UpdateAsyncUpdatesAdCorrectly()
        {
            var inputModel = new EditAdvertisementInputModel
            {
                Id = 1,
                Title = "editedTitle",
                Description = "editedDescription",
                Address = "editedAddress",
                PhoneNumber = "editedPhoneNumber",
                PetIsAdopted = true,
            };

            await this.Service.UpdateAsync(this.adId, inputModel);

            var adFromDb = this.DbContext.Advertisements.FirstOrDefault(a => a.Id == this.adId);

            Assert.Equal("editedTitle", adFromDb.Title);
            Assert.Equal("editedAddress", adFromDb.Address);
            Assert.Equal("editedDescription", adFromDb.Description);
            Assert.Equal("editedPhoneNumber", adFromDb.PhoneNumber);
            Assert.Equal(true, adFromDb.Pet.IsAdopted);
        }

        [Fact]
        public async Task UpdateAsyncShouldThrowArgumentNullExceptionWithInvalidAdId()
        {
            var inputModel = new EditAdvertisementInputModel
            {
                Id = 1,
                Title = "editedTitle",
                Description = "editedDescription",
                Address = "editedAddress",
                PhoneNumber = "editedPhoneNumber",
                PetIsAdopted = true,
            };

            await Assert.ThrowsAsync<NullReferenceException>(() => this.Service.UpdateAsync(0, inputModel));
        }

        [Fact]
        public async Task DeleteAsyncDeleteAdCorrectly()
        {
            await this.Service.DeleteAsync(this.adId);
            Assert.Equal(0, this.DbContext.Advertisements.Count());
        }

        [Fact]
        public async Task DeleteAsyncShouldThrowArgumentNullExceptionWithInvalidAdId()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() => this.Service.DeleteAsync(0));
        }

        [Fact]
        public void GetAllAdsShouldReturnCorrectCount()
        {
            var ads = this.Service.GetAllAdvertisements<AdvertisementInListViewModel>(1, 12);
            Assert.Single(ads);

            foreach (var ad in ads)
            {
                Assert.Equal("Test ad", ad.Title);
                Assert.Equal("Test description is here...", ad.Description);
                Assert.Equal("Test address", ad.Address);
                Assert.Equal("Test pet name", ad.Pet.Name);
            }
        }

        [Fact]
        public void GetRecentAdsShouldReturnCorrectResult()
        {
            var ads = this.Service.GetRecentAdvertisements<AdvertisementInListViewModel>();
            Assert.Single(ads);
        }

        [Fact]
        public void GetAdsCount()
        {
            var adsCount = this.Service.GetAdsCount();
            Assert.Equal(1, adsCount);
        }

        [Fact]
        public void GetByIdThrowsArgumentNullExceptionIfInvalidId()
        {
            Assert.Throws<ArgumentNullException>(() => this.Service.GetById<SingleAdvertisementViewModel>(0));
            Assert.Throws<ArgumentNullException>(() => this.Service.GetById<SingleAdvertisementViewModel>(-1));
            Assert.Throws<ArgumentNullException>(() => this.Service.GetById<SingleAdvertisementViewModel>(1111111));
        }

        [Fact]
        public void GetByUserIdReturnsCorrectRecord()
        {
            var userAds = this.Service.GetByUserId<AdvertisementInListViewModel>(this.userId);
            Assert.Single(userAds);
        }

        [Fact]
        public void GetByUserIdThrowsArgumentNullExceptionIfInvalidId()
        {
            Assert.Throws<ArgumentNullException>(() => this.Service.GetByUserId<SingleAdvertisementViewModel>(""));
            Assert.Throws<ArgumentNullException>(() => this.Service.GetByUserId<SingleAdvertisementViewModel>("a"));
            Assert.Throws<ArgumentNullException>(() => this.Service.GetByUserId<SingleAdvertisementViewModel>(" "));
        }

        [Fact]
        public void GetByCategoryReturnsCorrectRecord()
        {
            var categoryAds = this.Service.GetByCategory<AdvertisementInListViewModel>(this.categoryId);
            Assert.Single(categoryAds);
        }

        [Fact]
        public void GetByCategoryShouldReturnEmptyListIfCategoryIdIsInvalid()
        {
            var ads = this.Service.GetByCategory<AdvertisementInListViewModel>(0);
            Assert.Empty(ads);
        }

        [Fact]
        public void TestIsAuthorOfAdWithCorrectData()
        {
            var actualResult = this.Service.IsAuthorOfAd(this.adId, this.userId);
            Assert.True(actualResult);
        }

        [Fact]
        public void TestIsAuthorOfAdShouldReturnFalseIfUserIdNotValid()
        {
            var actualResult = this.Service.IsAuthorOfAd(this.adId, "");
            Assert.False(actualResult);
        }

        [Fact]
        public void TestIsAuthorOfAdShouldReturnFalseIfUserIdIsEmpty()
        {
            var actualResult = this.Service.IsAuthorOfAd(this.adId, " ");
            Assert.False(actualResult);
        }

        [Fact]
        public void TestIsAuthorOfAdShouldReturnFalseIfAdIdIsInvalid()
        {
            var actualResult = this.Service.IsAuthorOfAd(0, this.userId);
            Assert.False(actualResult);
        }
    }
}
