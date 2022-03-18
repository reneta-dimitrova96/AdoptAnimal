namespace AdoptAnimal.Web.ViewModels.Pets
{
    using System.ComponentModel.DataAnnotations;

    public class PetImagesInputModel
    {
        [Required]
        public string Extension { get; set; }

        [Required]
        public string Label { get; set; }

        public int PetId { get; set; }
    }
}
