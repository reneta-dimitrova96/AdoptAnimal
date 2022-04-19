namespace AdoptAnimal.Web.ViewModels.SearchAdvertisements
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class CategoryNameIdViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
