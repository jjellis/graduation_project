using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;


namespace LubbockLocalRestaurant.Core.Models
{
    public class AppUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
            {
                return FirstName + " " + LastName;
            } }
        public IEnumerable<Review> UserReviews { get; set; }
        public IEnumerable<Restaurant> FavoriteRestaurants { get; set; }
        /*TODO - Add image support*/
        public string ProfileImage { get; set; }
        public string Address { get; set; }
    }
}
