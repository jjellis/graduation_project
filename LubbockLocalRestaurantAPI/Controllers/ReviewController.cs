using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        // GET: api/Review
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Review = _reviewService.GetAll().ToAPIModels();
                if (Review == null) return NotFound();
                return Ok(Review);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllReviews", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Review = _reviewService.Get(id).ToAPIModel();
                if (Review == null) return NotFound();
                return Ok(Review);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetReviewById", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST: api/Review
        [HttpPost]
        public IActionResult Post([FromBody] ReviewModel reviewModel)
        {
            try
            {
                var Review = _reviewService.Add(reviewModel.ToDomainModel());
                return Ok(Review);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostReview", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public IActionResult Put(int reviewId, [FromBody] ReviewModel reviewModel)
        {
            try
            {
                reviewModel.Id = reviewId;
                var Review = _reviewService.Update(reviewModel.ToDomainModel());
                if (Review == null) return NotFound();
                return Ok(Review.ToAPIModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateReview", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Review = _reviewService.Get(id);
                if (Review == null) return NotFound();
                _reviewService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RemoveReview", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
