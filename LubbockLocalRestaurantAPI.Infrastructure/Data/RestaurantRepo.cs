using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurantAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LubbockLocalRestaurant.Infrastructure.Data
{
    public class RestaurantRepo:IRestaurantRepo
    {
        private readonly AppDbContext _dbContext;
        public RestaurantRepo(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant;
        }
        public Restaurant Update(Restaurant restaurant)
        {
            var ExistingResaurant = _dbContext.Restaurants
                .FirstOrDefault(r => r.Id == restaurant.Id);
            if (ExistingResaurant == null) return null;
            _dbContext.Entry(ExistingResaurant).CurrentValues
                .SetValues(restaurant);
            _dbContext.Update(ExistingResaurant);
            _dbContext.SaveChanges();
            return restaurant;

        }
        public Restaurant Get(int id)
        {
            var Restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
            if (Restaurant == null) return null;
            return Restaurant;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            var Restaurants = _dbContext.Restaurants;
            if (Restaurants == null) return null;
            return Restaurants;
        }
        public void Remove(int id)
        {
            var ExistingRestaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
            if (ExistingRestaurant == null) throw new SystemException("The Restaurant you are trying to delete was not found.");
            _dbContext.Restaurants.Remove(ExistingRestaurant);
            _dbContext.SaveChanges();


        }
    }
}
