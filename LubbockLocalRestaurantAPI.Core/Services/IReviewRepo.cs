using LubbockLocalRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LubbockLocalRestaurant.Infrastructure.Data
{
    public interface IReviewRepo
    {
        Review Add(Review review);
        Review Update(Review review);
        Review Get(int id);
        IEnumerable<Review> GetAll();
        void Remove(int id);
        IEnumerable<Review> GetAllReviwsForRestaurant(int restaurantId);
    }
}
