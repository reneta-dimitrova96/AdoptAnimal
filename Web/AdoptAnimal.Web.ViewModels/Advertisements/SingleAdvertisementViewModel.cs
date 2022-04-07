namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System;
    using System.Collections.Generic;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Comments;
    using AdoptAnimal.Web.ViewModels.Pets;
    using AdoptAnimal.Web.ViewModels.Statistics;
    using AutoMapper;

    public class SingleAdvertisementViewModel : IMapFrom<Advertisement>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string AuthorUserName { get; set; }

        public GetPetInputModel Pet { get; set; }

        public StatisticViewModel Statistic { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Advertisement, SingleAdvertisementViewModel>()
                .ForMember(a => a.AuthorUserName, opt =>
                opt.MapFrom(a => a.Author.UserName));

            configuration.CreateMap<Advertisement, SingleAdvertisementViewModel>()
                .ForMember(a => a.Pet, opt =>
                opt.MapFrom(a => a.Pet));

            configuration.CreateMap<Advertisement, SingleAdvertisementViewModel>()
                .ForMember(a => a.Statistic, opt =>
                opt.MapFrom(a => a.Statistic));

            configuration.CreateMap<Advertisement, SingleAdvertisementViewModel>()
                .ForMember(a => a.Comments, opt =>
                opt.MapFrom(a => a.Comments));
        }
    }
}
