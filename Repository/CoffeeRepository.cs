using CoffeeReviewApp.Data;
using CoffeeReviewApp.Dto;
using CoffeeReviewApp.Interfaces;
using CoffeeReviewApp.Models;

namespace CoffeeReviewApp.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly DataContext _context;

        public CoffeeRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCoffee(int categoryId, Coffee coffee)
        {

           var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();


            var coffeeCategory = new CoffeeCategory()
            {
                Category = category,
                Coffee = coffee,
            };

            
            _context.Add(coffeeCategory);

            _context.Add(coffee);

            return Save();
        }

        public bool DeleteCoffee(Coffee coffee)
        {
            _context.Remove(coffee);
            return Save();
        }

        public Coffee GetCoffee(int id)
        {
            return _context.Coffees.Where(c => c.Id == id).FirstOrDefault();
        }

        public Coffee GetCoffee(string name)
        {
            return _context.Coffees.Where(c => c.Name == name).FirstOrDefault();
        }

        public decimal GetCoffeeRating(int coffeeId)
        {
            var review = _context.Reviews.Where(p => p.Coffee.Id == coffeeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Coffee> GetCoffees()
        {
            return _context.Coffees.OrderBy(p => p.Id).ToList();
        }

        public Coffee GetCoffeeTrimToUpper(CoffeeDto coffeeCreate)
        {
            return GetCoffees().Where(c => c.Name.Trim().ToUpper() == coffeeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool CoffeeExists(int coffeeId)
        {
            return _context.Coffees.Any(c => c.Id == coffeeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCoffee(int countryId, int categoryId, Coffee coffee)
        {
            _context.Update(coffee);
            return Save();
        }
    }
}