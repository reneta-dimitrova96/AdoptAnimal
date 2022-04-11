namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.Linq;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.SubCategories;
    using AutoMapper;

    public class GetGategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PetsCount { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<GetSubGategoryViewModel> SubCategories { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, GetGategoryViewModel>()
               .ForMember(c => c.SubCategories, opt =>
               opt.MapFrom(c => c.SubCategories));

            configuration.CreateMap<Category, GetGategoryViewModel>()
               .ForMember(c => c.PetsCount, opt =>
               opt.MapFrom(c => c.Pets.Count()));

            configuration.CreateMap<Category, GetGategoryViewModel>()
               .ForMember(c => c.ImageUrl, opt =>
               opt.MapFrom(c => c.Pets.FirstOrDefault().PetImages.FirstOrDefault().ImageUrl != null ?
                                c.Pets.FirstOrDefault().PetImages.FirstOrDefault().ImageUrl :
                                "/images/pets/" + c.Pets.FirstOrDefault().PetImages.FirstOrDefault().Id + "." + c.Pets.FirstOrDefault().PetImages.FirstOrDefault().Extension));
        }
    }
}
