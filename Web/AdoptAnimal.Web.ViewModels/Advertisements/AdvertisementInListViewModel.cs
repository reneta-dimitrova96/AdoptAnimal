namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Pets;
    using AutoMapper;

    public class AdvertisementInListViewModel : IMapFrom<Advertisement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }

        public PetInListShortViewModel Pet { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Advertisement, AdvertisementInListViewModel>()
                .ForMember(a => a.Pet, opt =>
                opt.MapFrom(a => a.Pet));
        }
    }
}
