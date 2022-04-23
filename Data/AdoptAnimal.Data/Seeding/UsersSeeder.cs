namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AdoptAnimal.Common;
    using AdoptAnimal.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Users.Any())
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@abv.bg",
            };

            var adminPassword = "admin123";

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
            }

            var user = new ApplicationUser
            {
                UserName = "user1",
                Email = "user@abv.bg",
            };

            var userPassword = "user123";

            await userManager.CreateAsync(user, userPassword);
        }
    }
}
