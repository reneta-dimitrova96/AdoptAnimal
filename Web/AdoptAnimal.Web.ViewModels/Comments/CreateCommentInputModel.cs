namespace AdoptAnimal.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputModel
    {
        public int AdvertisementId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Content { get; set; }
    }
}
