namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class GetGategoryInputModel
    {
        public string Name { get; set; }

        public int CountOfPets { get; set; }
    }
}
