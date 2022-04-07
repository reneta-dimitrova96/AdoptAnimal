namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    public class GetAllCategoriesViewModel
    {
        public IEnumerable<GetGategoryViewModel> Categories { get; set; }
    }
}
