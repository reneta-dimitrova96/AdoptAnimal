namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class ArticlesListViewModel : PagingViewModel
    {
       public IEnumerable<ArticleInListViewModel> Articles { get; set; }
    }
}
