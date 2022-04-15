namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    public class SubCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SubCategories.Any())
            {
                return;
            }

            var rodentCategory = dbContext.Categories.Where(c => c.Name == "Гризачи").ToArray();
            if (rodentCategory.Length > 0)
            {
                await dbContext.SubCategories.AddAsync(new SubCategory
                {
                    Name = "Зайци",
                    CategoryId = rodentCategory[0].Id,
                });
                await dbContext.SubCategories.AddAsync(new SubCategory
                {
                    Name = "Хамстери",
                    CategoryId = rodentCategory[0].Id,
                });
            }

            var birdsCategory = dbContext.Categories.Where(c => c.Name == "Птици").ToArray();
            if (birdsCategory.Length > 0)
            {
                await dbContext.SubCategories.AddAsync(new SubCategory
                {
                    Name = "Канарчета",
                    CategoryId = birdsCategory[0].Id,
                });
                await dbContext.SubCategories.AddAsync(new SubCategory
                {
                    Name = "Папагали",
                    CategoryId = birdsCategory[0].Id,
                });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
