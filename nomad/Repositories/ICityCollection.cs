using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nomad.Models;

namespace nomad.Repositories
{
    public interface ICityCollection
    {
        Task InsertCity(cityModel city);
        Task UpdateCity(cityModel city);
        Task DeleteCity(string id);

        Task<List<cityModel>> GetAllCities();
        Task<cityModel> GetCityById(string id);
    }
}
