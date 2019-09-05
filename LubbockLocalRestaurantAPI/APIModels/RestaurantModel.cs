using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LubbockLocalRestaurant.Core.Models;

namespace LubbockLocalRestaurantAPI.APIModels
{
    public class RestaurantModel
    {
        public string RestaurantName { get; set; }
        public int Id { get; set; }
        public ResaurantType ResaurantType { get; set; }
        public string FoodType { get; set; }
        //Price range should be on a scale of 1-5
        public double PriceRange { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }
        /*TODO - Add a link to good api based off address*/
        /*TODO - Add a picture*/
        public string Image { get; set; }
        public bool Alcohol { get; set; }
        /*TODO - add link to yelp api*/
        public string RestaurantWebsite { get; set; }
        public string PhoneNumber { get; set; }
        public bool DeliveryService { get; set; }
        public double AverageUserScores
        {
            get
            {
                var sum = 0;
                /*TODO - Add code to add average review score*/
                return sum;

            }
        }
    }
}
