using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubbockLocalRestaurantAPI.APIModels
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        //user score must be between 1 and 5
        public int UserScore { get; set; }
        public string ReviewTitle { get; set; }
        public string UserReview { get; set; }
    }
}
