namespace AdoptAnimal.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class GetGategoryInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public int CountOfPets { get; set; }
    }
}
