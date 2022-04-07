namespace AdoptAnimal.Web.ViewModels.Comments
{
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string AuthorUserName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.AuthorUserName, opt =>
                opt.MapFrom(c => c.Author.UserName));
        }
    }
}
