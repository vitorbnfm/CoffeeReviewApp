using CoffeeReviewApp.Dto;
using CoffeeReviewApp.Models;

namespace CoffeeReviewApp.Interfaces
{
    public interface ICoffeeRepository
    {
        ICollection<Coffee> GetCoffees();
        Coffee GetCoffee(int id);
        Coffee GetCoffee(string name);
        Coffee GetCoffeeTrimToUpper(CoffeeDto coffeeCreate);
        decimal GetCoffeeRating(int coffeeId);
        bool CoffeeExists(int coffeeId);
        bool CreateCoffee(int categoryId, Coffee coffee);
        bool UpdateCoffee(int countryId, int categoryId, Coffee coffee);
        bool DeleteCoffee(Coffee coffee);
        bool Save();
    }
}