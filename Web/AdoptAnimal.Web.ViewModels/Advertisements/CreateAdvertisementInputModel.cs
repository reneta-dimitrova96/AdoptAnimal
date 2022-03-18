namespace AdoptAnimal.Web.ViewModels.Ads
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateAdvertisementInputModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PetsItems { get; set; }
    }
}
