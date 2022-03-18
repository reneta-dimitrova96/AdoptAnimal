namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GetAllArticlesInputModel
    {
       public IEnumerable<GetArticleInputModel> Articles { get; set; }
    }
}
