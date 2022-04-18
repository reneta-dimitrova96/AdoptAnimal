namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Кучета" });
            await dbContext.Categories.AddAsync(new Category { Name = "Котки" });
            await dbContext.Categories.AddAsync(new Category { Name = "Зайци" });
            await dbContext.Categories.AddAsync(new Category { Name = "Хамстери" });
            await dbContext.Categories.AddAsync(new Category { Name = "Папагали" });
            await dbContext.Categories.AddAsync(new Category { Name = "Рибки" });
            await dbContext.Categories.AddAsync(new Category { Name = "Костенурки" });

            await dbContext.SaveChangesAsync();
        }
    }
}
