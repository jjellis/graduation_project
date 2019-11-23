using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurant.Core.Services;
using LubbockLocalRestaurantAPI.APIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LubbockLocalRestaurantAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IReviewService _reviewService;
        public RestaurantController(IRestaurantService restaurantService, IReviewService reviewService)
        {
            _restaurantService = restaurantService;
            _reviewService = reviewService;
        }
        // GET: api/Restaurant
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Restaurant = _restaurantService.GetAll();
                if (Restaurant == null) return NotFound();
                return Ok(Restaurant.ToAPIModels());
            }catch(Exception ex)
            {
                ModelState.AddModelError("GetAllRestaurants", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET: api/Restaurant/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Restaurant = _restaurantService.Get(id);
                if (Restaurant == null) return NotFound();
               
                return Ok(Restaurant.ToAPIModel());
            }catch (Exception ex)
            {
                ModelState.AddModelError("GetRestaurantById", ex.Message);
                return BadRequest(ModelState);
            }
        }
        [AllowAnonymous]
        [HttpGet("{id}/reviews")]
        public IActionResult GetReviews(int id)
        {
            try
            {
                var reviews = _reviewService.GetAllReviwsForRestaurant(id);
                if (reviews == null) return NotFound();

                return Ok(reviews.ToAPIModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetReviewsByRestaurantId", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST: api/Restaurant
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantModel restaurantModel)
        {
            try
            {
                var Restaurant = _restaurantService.Add(restaurantModel.ToDomainModel());
                return Ok(Restaurant);
            }catch(Exception ex)
            {
                ModelState.AddModelError("PostRestaurant", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RestaurantModel restaurantModel)
        {
            try
            {
                restaurantModel.Id = id;
                var Restaurant = _restaurantService.Update(restaurantModel.ToDomainModel());
                if (Restaurant == null) return NotFound();
                return Ok(Restaurant.ToAPIModel());
            }catch(Exception ex)
            {
                ModelState.AddModelError("UpdateRestaurant", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Restaurant = _restaurantService.Get(id);
                if (Restaurant == null) return NotFound();
                _restaurantService.Remove(id);
                return NoContent();
            }catch(Exception ex)
            {
                ModelState.AddModelError("RemoveResaurant", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
