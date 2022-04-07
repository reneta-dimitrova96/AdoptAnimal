namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Pets;

    public interface IPetsService
    {
        Task<int> CreateAsync(CreatePetInputModel input);

        IEnumerable<KeyValuePair<int, string>> GetAllGenderTypes();

        IEnumerable<KeyValuePair<int, string>> GetAllIsDewormedEnumNames();

        IEnumerable<KeyValuePair<string, string>> GetAllPetsAsKeyValuePairs();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 9);

        int GetPetsCount();
    }
}
