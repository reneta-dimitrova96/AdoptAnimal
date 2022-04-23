namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    public class AdvertisementsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Advertisements.Any())
            {
                return;
            }

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Подарявам зайчето Джоуи",
                Description = "Джоуи е много игрив, изключително дружелюбен и гальовен. Подарявам го заедно с клетка, храна и сено. Здраво и гледано с много любов.",
                PhoneNumber = "0897168122",
                Address = "гр. София ул. Александър Божинов 44",
                Pet = new Pet()
                {
                    Name = "Джоуи",
                    Age = 1,
                    Weight = 3.5,
                    Breed = "Калифорния",
                    Gender = Models.Enums.GenderType.Male,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Зайци" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2014/06/21/08/43/rabbit-373691_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Чилийска катеричка дегу",
                Description = "Подарява се мъжко дегу. Катеричката е на 4 месеца и отговаря на името си. Свикнал е с хората и търси вниманието им.",
                PhoneNumber = "0891188761",
                Address = "гр. Добрич ул. Ивайло 3",
                Pet = new Pet()
                {
                    Name = "Дарко",
                    Age = 1,
                    Weight = 1,
                    Breed = "Чилийско дегу",
                    Gender = Models.Enums.GenderType.Male,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Други" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2017/06/04/16/36/squirrel-2371509_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Подарявам хамстер.",
                Description = "Хамстера е домашен, шарен, не хапе, не мирише. Намира се в град София.",
                PhoneNumber = "0890011881",
                Address = "гр. София ул. Ралица 2",
                Pet = new Pet()
                {
                    Name = "Шишо",
                    Age = 1,
                    Weight = 1,
                    Gender = Models.Enums.GenderType.Male,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Хамстери" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2018/02/17/17/50/cute-3160464_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Подарявам женско кастрирано коте",
                Description = "Подарявам женско кастрирано коте на една година. Много кротко, мило и гальовно животинче.",
                PhoneNumber = "0889898771",
                Address = "гр. Костинброд ул. Иван Караджов 43",
                Pet = new Pet()
                {
                    Name = "Дари",
                    Age = 1,
                    Weight = 1,
                    Gender = Models.Enums.GenderType.Female,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Котки" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2022/03/27/11/23/cat-7094808_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Сладка немска овчарка търси своя нов дом",
                Description = "Подарявам тази красавица, защото нямам възможност да се грижа за нея. Има паспорт и всички нужни ваксини.",
                PhoneNumber = "0878966712",
                Address = "гр. Дългопол ул. Катя Попова 17",
                Pet = new Pet()
                {
                    Name = "Лили",
                    Age = 2,
                    Weight = 25,
                    Breed = "Немска овчарка",
                    Gender = Models.Enums.GenderType.Female,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Кучета" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2017/10/04/20/42/dog-2817560_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Търсим дом за тази красива Мъжка Корела",
                Description = "Мъжка Корела на 1 година. Обича да пее и чурулика.",
                PhoneNumber = "0898171444",
                Address = "гр. Пловдив ул. Георги Бенковски 19",
                Pet = new Pet()
                {
                    Name = "Пол",
                    Age = 1,
                    Weight = 3,
                    Breed = "Корела",
                    Gender = Models.Enums.GenderType.Female,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Папагали" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2020/01/15/04/13/long-billed-corella-4766839_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Подарявам Рибка цихлиди",
                Description = "Рибките се подаряват с аквариум и всички нужни приспособления за отглеждането им.",
                PhoneNumber = "0898989666",
                Address = "гр. София ул. Николай Ракитин 3",
                Pet = new Pet()
                {
                    Age = 0,
                    Breed = "Цихлиди",
                    Gender = Models.Enums.GenderType.Female,
                    IsDewormed = Models.Enums.IsDewormed.Yes,
                    Category = new Category { Name = "Рибки" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2016/04/12/01/58/frontosa-1323598_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.Advertisements.AddAsync(new Advertisement()
            {
                Title = "Подарявам водна костенурка",
                Description = "Лео е здрав, много социален и лаком. Гледа се лесно. Не се изискват кой знае какви специални грижи.",
                PhoneNumber = "0887651199",
                Address = "гр. Ямбол ул. Райко Жинзифов 12",
                Pet = new Pet()
                {
                    Name = "Лео",
                    Age = 4,
                    Weight = 2.5,
                    Breed = "Водна костенурка",
                    Gender = Models.Enums.GenderType.Male,
                    IsDewormed = Models.Enums.IsDewormed.Unknown,
                    Category = new Category { Name = "Костенурки" },
                    PetImages = new List<PetImage>
                    {
                        new PetImage()
                        {
                            Extension = "jpg",
                            ImageUrl = "https://cdn.pixabay.com/photo/2018/09/28/21/51/turtle-3710323_960_720.jpg",
                        },
                    },
                },
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
