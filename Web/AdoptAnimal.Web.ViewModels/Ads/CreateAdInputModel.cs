namespace AdoptAnimal.Web.ViewModels.Ads
{
    using System.ComponentModel.DataAnnotations;

    public class CreateAdInputModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public string AuthorId { get; set; }
         
        public int PetId { get; set; }
    }
}
