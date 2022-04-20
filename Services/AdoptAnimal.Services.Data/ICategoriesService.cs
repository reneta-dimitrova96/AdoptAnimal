namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        T GetById<T>(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<T> GetAllCategories<T>();
    }
}
