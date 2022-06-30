using System;

namespace CoffeeReviewApp.Models
{
    public class Coffee
    {
        public Coffee() => Created = DateTime.Now;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public Country Country { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CoffeeCategory> CoffeeCategories { get; set; }
    }
}
