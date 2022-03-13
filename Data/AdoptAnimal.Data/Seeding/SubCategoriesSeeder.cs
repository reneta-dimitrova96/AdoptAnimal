namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    internal class SubCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SubCategories.Any())
            {
                return;
            }

            var arrayOfCategories = dbContext.Categories.Where(c => c.Name == "Гризачи").ToArray();
            if (arrayOfCategories.Length > 0)
            {
                await dbContext.SubCategories.AddAsync(new SubCategory
                {
                    Name = "Зайци",
                    CategoryId = arrayOfCategories[0].Id,
                });
                await dbContext.SubCategories.AddAsync(new SubCategory
                {
                    Name = "Хамстери",
                    CategoryId = arrayOfCategories[0].Id,
                });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
