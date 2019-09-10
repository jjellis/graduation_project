using LubbockLocalRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubbockLocalRestaurantAPI.APIModels
{
    public static class RestaurantMappingExtensions
    {
        public static RestaurantModel ToAPIModel(this Restaurant restaurant)
        {
            var Restaurant = new RestaurantModel
            {
                Id = restaurant.Id,
                RestaurantName = restaurant.RestaurantName,
                DeliveryService = restaurant.DeliveryService,
                Address = restaurant.Address,
                Alcohol = restaurant.Alcohol,
                FoodType = restaurant.FoodType,
                HoursOfOperation = restaurant.HoursOfOperation,
                Image = restaurant.Image,
                PhoneNumber = restaurant.PhoneNumber,
                PriceRange = restaurant.PriceRange,
                RestaurantType = restaurant.RestaurantType,
                RestaurantWebsite = restaurant.RestaurantWebsite
            };
            return Restaurant;
        }

        public static Restaurant ToDomainModel(this RestaurantModel restaurant)
        {
            var Restaurant = new Restaurant
            {
                Id = restaurant.Id,
                RestaurantName = restaurant.RestaurantName,
                DeliveryService = restaurant.DeliveryService,
                Address = restaurant.Address,
                Alcohol = restaurant.Alcohol,
                FoodType = restaurant.FoodType,
                HoursOfOperation = restaurant.HoursOfOperation,
                Image = restaurant.Image,
                PhoneNumber = restaurant.PhoneNumber,
                PriceRange = restaurant.PriceRange,
                RestaurantType = restaurant.RestaurantType,
                RestaurantWebsite = restaurant.RestaurantWebsite,
                
            };
            return Restaurant;
        }

        public static IEnumerable<RestaurantModel> ToAPIModels(this IEnumerable<Restaurant> restaurants)
        {
            var Restaurants = restaurants.Select(u => u.ToAPIModel());
            return Restaurants;
        }

        public static IEnumerable<Restaurant> ToDomainModels(this IEnumerable<RestaurantModel> restaurants)
        {
            var Restaurants = restaurants.Select(u => u.ToDomainModel());
            return Restaurants;
        }
    }
}
