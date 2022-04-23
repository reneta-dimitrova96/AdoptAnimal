namespace AdoptAnimal.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using AdoptAnimal.Data;
    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Data.Models.Enums;
    using AdoptAnimal.Data.Repositories;
    using AdoptAnimal.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            this.Configuration = this.SetConfiguration();
            var services = this.SetServices();
            this.InitializeMapper();
            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            this.Seed();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        protected IConfigurationRoot Configuration { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }

        private void InitializeMapper() => AutoMapperConfig.
    RegisterMappings(Assembly.Load("AdoptAnimal.Web.ViewModels"));

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddTransient<IGetCountsService, GetCountsService>();
            services.AddTransient<IAdvertisementsService, AdvertisementsService>();
            services.AddTransient<IPetsService, PetsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IArticlesService, ArticlesService>();
            services.AddTransient<ICommentsService, CommentsService>();

            var context = new DefaultHttpContext();
            services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor { HttpContext = context });

            return services;
        }

        private IConfigurationRoot SetConfiguration()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                 path: "appsettings.json",
                 optional: false,
                 reloadOnChange: true)
           .Build();
        }

        private void Seed()
        {
            var category = new Category
            {
                Name = "Test category name",
            };

            this.DbContext.Categories.Add(category);

            var user = new ApplicationUser
            {
                Email = "user@abv.bg",
                PasswordHash = "passsword",
                UserName = "tester",
            };

            this.DbContext.Users.Add(user);
            this.DbContext.SaveChanges();

            var userId = this.DbContext.Users.Select(u => u.Id).First();
            var categoryId = this.DbContext.Categories.Select(c => c.Id).First();

            var article = new Article
            {
                Title = "Test article name",
                Content = "Test article content is here",
                Source = "https://softuni.bg/",
                ImageUrl = "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/322868_1100-800x825.jpg",
                AuthorId = userId,
            };

            this.DbContext.Articles.Add(article);

            var ad = new Advertisement
            {
                Title = "Test ad",
                Description = "Test description is here...",
                PhoneNumber = "0876780040",
                Address = "Test address",
                AuthorId = userId,
                Pet = new Pet
                {
                    Name = "Test pet name",
                    Age = 2,
                    Gender = GenderType.Male,
                    Weight = 2,
                    Breed = "test breed",
                    IsDewormed = IsDewormed.Yes,
                    CategoryId = categoryId,
                    PetImages = new List<PetImage>
                    {
                        new PetImage
                        {
                            Extension = "jpg",
                            AuthorId = userId,
                        },
                    },
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Content = "Test Comment content",
                        AuthorId = userId,
                    },
                },
            };

            this.DbContext.Advertisements.Add(ad);
            this.DbContext.SaveChanges();

            var statistic = new Statistic
            {
                StartDate = new DateTime(2022, 3, 1, 8, 30, 52),
                EndDate = DateTime.Now,
                AdvertisementsCount = 1,
                PetsCount = 1,
                ArticlesCounts = 1,
                UsersCounts = 1,
            };

            this.DbContext.Statistics.Add(statistic);
            this.DbContext.SaveChanges();
        }
    }
}
