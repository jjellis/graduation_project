using LubbockLocalRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LubbockLocalRestaurantAPI.APIModels
{
    public static class AppUserMappingExtensions
    {
        public static AppUserModel ToAPIModel(this AppUser appUser)
        {
            var AppUser = new AppUserModel
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                Address = appUser.Address,
                ProfileImage = appUser.ProfileImage               
            };
            return AppUser;
        }

        public static AppUser ToDomainModel(this AppUserModel appUser)
        {
            var AppUser = new AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                Address = appUser.Address,
                ProfileImage = appUser.ProfileImage
            };
            return AppUser;
        }

        public static IEnumerable<AppUserModel> ToAPIModels(this IEnumerable<AppUser> appUsers)
        {
            var AppUsers =  appUsers.Select(u => u.ToAPIModel());
            return AppUsers;
        }

        public static IEnumerable<AppUser> ToDomainModels(this IEnumerable<AppUserModel> appUsers)
        {
            var AppUSers = appUsers.Select(u => u.ToDomainModel());
            return AppUSers;
        }

    }
}
