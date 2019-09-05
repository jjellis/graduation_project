using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LubbockLocalRestaurant.Core.Models;

namespace LubbockLocalRestaurantAPI.APIModels
{
    public class AppUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        /*TODO - Add image support*/
        public string ProfileImage { get; set; }
        public string Address { get; set; }
    }
}
