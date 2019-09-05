using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LubbockLocalRestaurant.Core.Services
{
    public class ReviewService: IReviewService
    {
        private readonly IReviewRepo _reviewRepo;
        public ReviewService(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }
        public Review Add(Review review)
        {
            var Review = _reviewRepo.Add(review);
            return Review;
        }
        public Review Update(Review review)
        {
            var Review = _reviewRepo.Update(review);
            return Review;
        }
        public Review Get(int id)
        {
            var Review = _reviewRepo.Get(id);
            return Review;
        }
        public IEnumerable<Review> GetAll()
        {
            var Reviews = _reviewRepo.GetAll();
            return Reviews;
        }
        public void Remove(int id)
        {
            _reviewRepo.Remove(id);
        }
        public IEnumerable<Review> GetAllReviwsForRestaurant(int restaurantId)
        {
            var ReviewsForRestaurant = _reviewRepo.GetAllReviwsForRestaurant(restaurantId);
            return ReviewsForRestaurant;
        }
    }
}
