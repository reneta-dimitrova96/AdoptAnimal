﻿namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System;
    using System.Linq;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class PetInListViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Pet, PetInListShortViewModel>()
                .ForMember(
                    p => p.ImageUrl, opt => opt.MapFrom(p =>
                    p.PetImages.FirstOrDefault().ImageUrl != null ?
                    p.PetImages.FirstOrDefault().ImageUrl :
                    "/images/pets/" + p.PetImages.FirstOrDefault().Id + "." + p.PetImages.FirstOrDefault().Extension));
        }
    }
}