using AutoMapper;
using CoffeeReviewApp.Dto;
using CoffeeReviewApp.Interfaces;
using CoffeeReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CoffeeController(ICoffeeRepository coffeeRepository,
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _coffeeRepository = coffeeRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coffee>))]
        public IActionResult GetCoffees()
        {
            var coffees = _mapper.Map<List<CoffeeDto>>(_coffeeRepository.GetCoffees());

            if (!ModelState.IsValid)
            {   
                return BadRequest(ModelState);
            }
                
            return Ok(coffees);
                
        }

        [HttpGet("{coffeeId}")]
        [ProducesResponseType(200, Type = typeof(Coffee))]
        [ProducesResponseType(400)]
        public IActionResult GetCoffee(int coffeeId)
        {
            if (!_coffeeRepository.CoffeeExists(coffeeId))
                return NotFound();

            var coffee = _mapper.Map<CoffeeDto>(_coffeeRepository.GetCoffee(coffeeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(coffee);
        }

        [HttpGet("{coffeeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetCoffeeRating(int coffeeId)
        {
            if (!_coffeeRepository.CoffeeExists(coffeeId))
                return NotFound();

            var rating = _coffeeRepository.GetCoffeeRating(coffeeId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCoffee([FromQuery] int catId, [FromBody] CoffeeDto coffeeCreate)
        {
            if (coffeeCreate == null)
                return BadRequest(ModelState);

            var coffees = _coffeeRepository.GetCoffeeTrimToUpper(coffeeCreate);

            if (coffees != null)
            {
                ModelState.AddModelError("", "already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var coffeeMap = _mapper.Map<Coffee>(coffeeCreate);

      
            if (!_coffeeRepository.CreateCoffee(catId, coffeeMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{coffeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCoffee(int coffeeId, [FromQuery] int catId, [FromBody] CoffeeDto updatedCoffee)
        {
            if (updatedCoffee == null)
                return BadRequest(ModelState);

            if (coffeeId != updatedCoffee.Id)
                return BadRequest(ModelState);

            if (!_coffeeRepository.CoffeeExists(coffeeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var coffeeMap = _mapper.Map<Coffee>(updatedCoffee);

            if (!_coffeeRepository.UpdateCoffee(catId, coffeeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{coffeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCoffee(int coffeeId)
        {
            if (!_coffeeRepository.CoffeeExists(coffeeId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfACoffee(coffeeId);
            var coffeeToDelete = _coffeeRepository.GetCoffee(coffeeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_coffeeRepository.DeleteCoffee(coffeeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}

