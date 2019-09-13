using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurantAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LubbockLocalRestaurant.Infrastructure.Data
{
    public class ReviewRepo:IReviewRepo
    {
        private readonly AppDbContext _dbContext;
        public ReviewRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public Review Add(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return review;
        }
        public Review Update(Review review)
        {
            var ExistingReview = _dbContext.Reviews.Include(u=>u.User).Include(r=>r.Restaurant).FirstOrDefault(r => r.Id == review.Id);
            if (ExistingReview == null) return null;
            _dbContext.Entry(ExistingReview).CurrentValues.SetValues(review);
            _dbContext.Update(ExistingReview);
            _dbContext.SaveChanges();
            return ExistingReview;
        }
        public Review Get(int id)
        {
            var Review = _dbContext.Reviews.Include(r=>r.Restaurant).Include(u=>u.User).FirstOrDefault(r => r.Id == id);
            if (Review == null) return null;
            return Review;
        }
        public IEnumerable<Review> GetAll()
        {
            var Reviews = _dbContext.Reviews.Include(r=> r.Restaurant).Include(u=>u.User);
            if (Reviews == null) return null;
            return Reviews;
        }
        public void Remove(int id)
        {
            var ExistingReview = _dbContext.Reviews.FirstOrDefault(r => r.Id == id);
            if (ExistingReview == null) throw new SystemException("The Review you are trying to delete was not found.");
            _dbContext.Remove(ExistingReview);
        }
        public IEnumerable<Review> GetAllReviwsForRestaurant(int restaurantId)
        {
            var Reviews = _dbContext.Reviews.Include(r => r.Restaurant).Include(r => r.User)
                .Where(r => r.RestaurantId == restaurantId).ToList();
            if (Reviews == null) return null;
            return Reviews;
        }
    }
}
