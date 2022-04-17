namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class EditAdvertisementInputModel : BaseAdvertisementInputModel, IMapFrom<Advertisement>
    {
        public int Id { get; set; }
    }
}
