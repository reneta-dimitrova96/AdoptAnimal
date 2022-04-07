namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class GetAllArticlesViewModel : PagingViewModel
    {
       public IEnumerable<GetArticleViewModel> Articles { get; set; }
    }
}
