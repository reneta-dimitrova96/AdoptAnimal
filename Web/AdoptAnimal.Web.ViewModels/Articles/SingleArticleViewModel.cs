namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;

    public class SingleArticleViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorUserName { get; set; }

        public ArticleImageViewModel ArticleImage { get; set; }
    }
}
