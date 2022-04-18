namespace AdoptAnimal.Web.ViewModels.Advertisements
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseAdvertisementInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Address { get; set; }
    }
}
