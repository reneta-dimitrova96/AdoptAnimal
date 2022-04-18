namespace AdoptAnimal.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputModel
    {
        public int AdvertisementId { get; set; }

        public string Content { get; set; }
    }
}
