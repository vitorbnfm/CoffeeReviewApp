using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeReviewApp.Dto
{
    public class CoffeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public CountryDto CountryDto { get; set; }
        
    }
}