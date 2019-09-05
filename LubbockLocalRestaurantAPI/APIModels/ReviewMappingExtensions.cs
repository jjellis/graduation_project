using LubbockLocalRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LubbockLocalRestaurantAPI.APIModels
{
    public static class ReviewMappingExtensions
    {
        public static ReviewModel ToAPIModel(this Review review)
        {
            var Review = new ReviewModel
            {
                Id = review.Id,
                RestaurantId = review.RestaurantId,
                RestaurantName = review.Restaurant.RestaurantName,
                ReviewTitle = review.ReviewTitle,
                UserId = review.UserId,
                UserName = review.User.UserName,
                UserReview = review.UserReview,
                UserScore = review.UserScore
            };
            return Review;
        }

        public static Review ToDomainModel(this ReviewModel review)
        {
            var Review = new Review
            {
               ReviewTitle = review.ReviewTitle,
               RestaurantId = review.RestaurantId,
               UserId = review.UserId,
               Id = review.Id,
               UserReview = review.UserReview,
               UserScore = review.UserScore
            };
            return Review;
        }

        public static IEnumerable<ReviewModel> ToAPIModels(this IEnumerable<Review> reviews)
        {
            var Reviews = reviews.Select(u => u.ToAPIModel());
            return Reviews;
        }

        public static IEnumerable<Review> ToDomainModels(this IEnumerable<ReviewModel> reviews)
        {
            var Reviews = reviews.Select(u => u.ToDomainModel());
            return Reviews;
        }
    }
}
