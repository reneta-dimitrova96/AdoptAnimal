namespace AdoptAnimal.Web.Tests.Controllers
{
    using System;

    using AdoptAnimal.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using NSubstitute;

    public static class MockUserManager
    {
        public static UserManager<ApplicationUser> Create()
        {
            return Substitute.For<UserManager<ApplicationUser>>(
                Substitute.For<IUserStore<ApplicationUser>>(),
                Substitute.For<IOptions<IdentityOptions>>(),
                Substitute.For<IPasswordHasher<ApplicationUser>>(),
                new IUserValidator<ApplicationUser>[0],
                new IPasswordValidator<ApplicationUser>[0],
                Substitute.For<ILookupNormalizer>(),
                Substitute.For<IdentityErrorDescriber>(),
                Substitute.For<IServiceProvider>(),
                Substitute.For<ILogger<UserManager<ApplicationUser>>>());
        }
    }
}
