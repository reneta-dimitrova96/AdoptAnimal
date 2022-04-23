namespace AdoptAnimal.Web.Tests.Controllers
{
    using System;
    using System.IO;
    using System.Reflection;

    using AdoptAnimal.Data;
    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Repositories;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseControllerTests : IDisposable
    {
        protected BaseControllerTests()
        {
            this.Configuration = this.SetConfiguration();
            var services = this.SetServices();
            this.InitializeMapper();
            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
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
            /*services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));*/

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
    }
}
