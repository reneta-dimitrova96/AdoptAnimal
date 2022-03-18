namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System.Collections.Generic;

    public class GetAllAdvertisementsInputModel
    {
        public IEnumerable<GetAdvertisementInputModel> Advertisements { get; set; }
    }
}
