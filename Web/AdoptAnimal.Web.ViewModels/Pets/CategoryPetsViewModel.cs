namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System.Collections.Generic;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class CategoryPetsViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public IEnumerable<PetInListViewModel> Pets { get; set; }
    }
}
