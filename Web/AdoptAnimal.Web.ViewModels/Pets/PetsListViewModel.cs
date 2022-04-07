namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PetsListViewModel : PagingViewModel
    {
        public IEnumerable<PetInListViewModel> Pets { get; set; }
    }
}
