namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    public class GetArticleInputModel
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
