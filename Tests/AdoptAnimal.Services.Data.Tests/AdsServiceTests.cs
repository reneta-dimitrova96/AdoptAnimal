namespace AdoptAnimal.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Data.Repositories;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Ads;
    using AdoptAnimal.Web.ViewModels.Pets;
    using Xunit;

    public class AdsServiceTests
    {
        private readonly IAdvertisementsService adsService;
        private EfDeletableEntityRepository<Advertisement> adsRepo;
        private EfDeletableEntityRepository<Pet> petsRepo;

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("AdoptAnimal.Web.ViewModels"));

        public AdsServiceTests()
        {
            this.InitializeMapper();
            this.adsService = new AdvertisementsService(this.adsRepo, this.petsRepo);
        }

        /*[Fact]
        public async Task TestAddingFaqEntry()
        {
            var model = new CreateAdvertisementInputModel
            {
                Title = "Test ad",
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                Pet = new CreatePetInputModel
                {
                    Name = "Test pet name",
                    Age = 2,
                    Weight = 2,
                    Breed = "test breed",
                    CategoryId = 1,
                },
            };

            await this.adsService.CreateAsync(model, "test userId", "wwwroot/images");
            var count = this.adsRepo.All().Count();

            Assert.Equal(1, count);
        }*/
    }
}
