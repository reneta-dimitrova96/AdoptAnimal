namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System.Collections.Generic;

    public class GetAllPetsInputModel
    {
        public IEnumerable<GetPetInputModel> Pets { get; set; }
    }
}
