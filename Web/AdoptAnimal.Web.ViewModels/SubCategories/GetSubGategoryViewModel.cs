namespace AdoptAnimal.Web.ViewModels.SubCategories
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class GetSubGategoryViewModel : IMapFrom<SubCategory>
    {
        public string Name { get; set; }
    }
}
