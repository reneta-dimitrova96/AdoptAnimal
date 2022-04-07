namespace AdoptAnimal.Web.ViewModels.Articles
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class ArticleImageViewModel : IMapFrom<ArticleImage>
    {
        public string Source { get; set; }
    }
}
