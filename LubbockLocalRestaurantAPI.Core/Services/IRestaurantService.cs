﻿using LubbockLocalRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LubbockLocalRestaurant.Core.Services
{
    public interface IRestaurantService
    {
        Restaurant Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
        Restaurant Get(int id);
        IEnumerable<Restaurant> GetAll();
        void Remove(int id);
    }
}
