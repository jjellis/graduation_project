using LubbockLocalRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LubbockLocalRestaurant.Infrastructure.Data
{
    public interface IUserRepo
    {
        AppUser Add(AppUser user);
        AppUser Update(AppUser user);
        AppUser Get(int id);
        IEnumerable<AppUser> GetAll();
        void Remove(int id);
    }
}
