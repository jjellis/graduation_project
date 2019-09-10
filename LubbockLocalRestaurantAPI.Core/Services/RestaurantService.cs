using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

/*TODO - Add phone number, address validation*/
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
            var yelp = GetYelpApiJsonForRestaurant(restaurant.PhoneNumber);
            restaurant.YelpJSON = yelp;
            var Restaurant = _restaurantRepo.Add(restaurant);
            return Restaurant;
        }
        public Restaurant Update(Restaurant restaurant)
        {
            var yelp = GetYelpApiJsonForRestaurant(restaurant.PhoneNumber);
            restaurant.YelpJSON = yelp;
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

        public string GetYelpApiJsonForRestaurant(string phoneNumber)
        {
            string urltest = string.Format("https://api.yelp.com/v3/businesses/search/phone?phone=+18067854025");
            WebRequest requestObject = WebRequest.Create(urltest);
            requestObject.PreAuthenticate = true;
            requestObject.Headers.Add("Authorization", "Bearer " + "Gx-v1l6hahIJLVv_eq-3oqzH0m3Ub35LOCXI9q7rCAn8dq-B1-ziT5GAGzatpjVWsVO7hmudTkv3fgYejI_gmmJKYuoQLWFSLYYz5rh-qjS-fggH_-l9Uc0dK_NyXXYx");

            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();
            string resultTest = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader re = new StreamReader(stream);
                resultTest = re.ReadToEnd();
                re.Close();
            }
            if (resultTest == null) return null;
            return resultTest;
        }
    }
}
