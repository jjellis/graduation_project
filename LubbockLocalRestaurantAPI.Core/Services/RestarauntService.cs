using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace LubbockLocalRestaurant.Core.Services
{
    public class RestarauntService:IRestaurantService
    {
        private readonly IRestaurantRepo _restaurantRepo;
        public RestarauntService(IRestaurantRepo restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            var Restaurant = _restaurantRepo.Add(restaurant);
            return Restaurant;
        }
        public Restaurant Update(Restaurant restaurant)
        {
            var Restaurant = _restaurantRepo.Update(restaurant);
            return Restaurant;
        }
        public Restaurant Get(int id)
        {
            var Restaurant = _restaurantRepo.Get(id);
            return Restaurant;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            var Restaurants = _restaurantRepo.GetAll();
            return Restaurants;
        }
        public void Remove(int id)
        {
            _restaurantRepo.Remove(id);
        }
    }
}
