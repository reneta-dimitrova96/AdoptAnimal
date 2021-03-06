namespace AdoptAnimal.Web.ViewModels.Comments
{
    using System;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class CommentInListViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string AuthorUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentInListViewModel>()
                .ForMember(c => c.AuthorUserName, opt =>
                opt.MapFrom(c => c.Author.UserName));
        }
    }
}
