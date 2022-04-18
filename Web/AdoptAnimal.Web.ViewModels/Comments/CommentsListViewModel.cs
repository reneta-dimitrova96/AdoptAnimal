namespace AdoptAnimal.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    public class CommentsListViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
