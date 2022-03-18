namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System.ComponentModel.DataAnnotations;

    public class GetAdvertisementInputModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
