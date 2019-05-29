namespace Shop.Web.Data
{
    using Entities;
    using Shop.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICountryRepository : IGenericRepository<Country>
    {
        IQueryable GetContriesWithCities();

        Task<Country> GetCountriesWithCitiesAsync(int id);

        Task<City> GetCityAsync(int id);

        Task AddCityAsync(CityViewModel model);

        Task<int> UpdateCityAsycn(City city);

        Task<int> DeleteCityAsync(City city);
    }
}
