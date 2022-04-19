namespace AdoptAnimal.Web.ViewModels.SearchAdvertisements
{
    using System.Collections.Generic;

    public class SearchIndexViewModel
    {
        public IEnumerable<CategoryNameIdViewModel> Categories { get; set; }
    }
}
