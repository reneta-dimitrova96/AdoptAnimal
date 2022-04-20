namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.Linq;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class CategoryInListViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PetsCount { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, CategoryInListViewModel>()
               .ForMember(c => c.PetsCount, opt =>
               opt.MapFrom(c => c.Pets.Count()));

            configuration.CreateMap<Category, CategoryInListViewModel>()
               .ForMember(c => c.ImageUrl, opt =>
               opt.MapFrom(c => c.Pets.FirstOrDefault().PetImages.FirstOrDefault().ImageUrl != null ?
                                c.Pets.FirstOrDefault().PetImages.FirstOrDefault().ImageUrl :
                                "/images/pets/" + c.Pets.FirstOrDefault().PetImages.FirstOrDefault().Id + "." + c.Pets.FirstOrDefault().PetImages.FirstOrDefault().Extension));
        }
    }
}
