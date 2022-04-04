namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AdoptAnimal.Web.ViewModels.Pets;

    public class AdvertisementInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        // public string AuthorId { get; set; }

        public PetInListShortViewModel Pet { get; set; }
    }
}
