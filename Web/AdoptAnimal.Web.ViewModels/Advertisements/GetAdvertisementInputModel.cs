namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System.ComponentModel.DataAnnotations;

    public class GetAdvertisementInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
    }
}
