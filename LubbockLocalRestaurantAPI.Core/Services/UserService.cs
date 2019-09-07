using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LubbockLocalRestaurant.Core.Services
{
    /*TODO - Redo User services and repo after studying user Indentity more*/
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public AppUser Add(AppUser user)
        {
            var User = _userRepo.Add(user);
            return User;
        }
        public AppUser Update(AppUser user)
        {
            var User = _userRepo.Update(user);
            return User;
        }
        public AppUser Get(int id)
        {
            var User = _userRepo.Get(id);
            return User;
        }
        public IEnumerable<AppUser> GetAll()
        {
            var Users = _userRepo.GetAll();
            return Users;
        }
        public void Remove(int id)
        {
            _userRepo.Remove(id);
        }
    }
}
