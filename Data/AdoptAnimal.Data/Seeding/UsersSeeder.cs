namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }
        }
    }
}
