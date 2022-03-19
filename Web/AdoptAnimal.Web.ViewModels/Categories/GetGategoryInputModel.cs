namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Web.ViewModels.SubCategories;

    public class GetGategoryInputModel
    {
        public string Name { get; set; }

        public int CountOfPets { get; set; }

        public IEnumerable<GetSubGategoryInputModel> SubCategories { get; set; }
    }
}
