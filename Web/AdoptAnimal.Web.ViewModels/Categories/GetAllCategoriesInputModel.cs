namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    public class GetAllCategoriesInputModel
    {
        public IEnumerable<GetGategoryInputModel> Categories { get; set; }
    }
}
