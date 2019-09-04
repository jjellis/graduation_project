using System;
using System.Collections.Generic;
using System.Text;

namespace LubbockLocalRestaurant.Core.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; } 
        //user score must be between 1 and 5
        public int UserScore { get; set; }
        public string ReviewTitle { get; set; }
        public string UserReview { get; set; }
    }
}
