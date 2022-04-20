namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class EditAdvertisementInputModel : BaseAdvertisementInputModel, IMapFrom<Advertisement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public bool PetIsAdopted { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Advertisement, EditAdvertisementInputModel>()
               .ForMember(a => a.PetIsAdopted, opt =>
               opt.MapFrom(a => a.Pet.IsAdopted));
        }
    }
}
