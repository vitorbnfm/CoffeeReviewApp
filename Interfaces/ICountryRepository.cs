using CoffeeReviewApp.Models;

namespace CoffeeReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        ICollection<Coffee> GetCoffeeFromACountry(int countryId);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}