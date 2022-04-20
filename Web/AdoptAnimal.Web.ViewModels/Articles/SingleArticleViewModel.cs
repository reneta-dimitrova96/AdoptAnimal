namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class SingleArticleViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorUserName { get; set; }

        public string Source { get; set; }

        public string ImageUrl { get; set; }
    }
}
