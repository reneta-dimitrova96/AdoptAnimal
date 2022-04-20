namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class PetImageViewModel : IMapFrom<PetImage>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PetImage, PetImageViewModel>()
                .ForMember(
                    p => p.ImageUrl, opt => opt.MapFrom(p =>
                    p.ImageUrl != null ?
                    p.ImageUrl :
                    "/images/pets/" + p.Id + "." + p.Extension));
        }
    }
}
