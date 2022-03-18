﻿namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoptAnimal.Web.ViewModels.Pets;

    public interface IPetsService
    {
        Task CreateAsync(CreatePetInputModel input);

        IEnumerable<KeyValuePair<int, string>> GetAllIsDewormedEnumNames();

        IEnumerable<KeyValuePair<string, string>> GetAllPetsAsKeyValuePairs();

        GetAllPetsInputModel GetAllPets();
    }
}