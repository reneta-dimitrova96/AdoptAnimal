namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class SingleArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorUserName { get; set; }

        public ArticleImageViewModel ArticleImage { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, SingleArticleViewModel>()
                .ForMember(a => a.AuthorUserName, opt =>
                opt.MapFrom(a => a.Author.UserName));
        }
    }
}
