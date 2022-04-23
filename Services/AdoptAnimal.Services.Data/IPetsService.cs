namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Pets;

    public interface IPetsService
    {
        IEnumerable<KeyValuePair<int, string>> GetAllGenderTypes();

        IEnumerable<KeyValuePair<int, string>> GetAllIsDewormedEnumNames();

        IEnumerable<KeyValuePair<string, string>> GetAllPetsAsKeyValuePairs();

        IEnumerable<T> GatAllPets<T>(int page, int itemsPerPage = 9);

        int GetPetsCount();

        T GetById<T>(int id);
    }
}
