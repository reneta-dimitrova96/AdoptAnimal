namespace AdoptAnimal.Web.ViewModels.SubCategories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateSubCategoryInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
