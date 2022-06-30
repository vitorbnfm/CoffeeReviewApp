using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeReviewApp.Models
{
    public class CoffeeCategory
    {
        public int CoffeeId { get; set; }
        public int CategoryId { get; set; }
        public Coffee Coffee { get; set; }
        public Category Category { get; set; }
    }
}