namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        Task CreateAsync(CreateCommentInputModel input);

        IEnumerable<T> GetAllCommentsByAdId<T>(int advertisementId);

        int GetCommentsCount();
    }
}
