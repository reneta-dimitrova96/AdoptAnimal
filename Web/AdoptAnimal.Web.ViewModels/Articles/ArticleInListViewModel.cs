namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System;
    using System.Linq;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class ArticleInListViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Source { get; set; }

        public string ImageUrl { get; set; }
    }
}
