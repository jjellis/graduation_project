using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurant.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubbockLocalRestaurantAPI
{
    public class DbInitializer
    {
        private readonly IReviewRepo _reviewRepo;
        private readonly IRestaurantRepo _restaurantRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IRestaurantRepo restaurantRepo, IReviewRepo reviewRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _restaurantRepo = restaurantRepo;
            _reviewRepo = reviewRepo;
        }

        public void Initialize()
        {
            AddAdminUser();
            AddTestUsers();
            AddTestRestaurant();

        }

        public void AddTestUsers()
        {
            var testUsers = new[] {
                new
                {
                    Email = "steven_schoor@yahoo.com",
                    FirstName = "Steven",
                    LastName = "Schoor",
                    Address = "1002 Frankford ave",
                    ProfileImage = "profile1.jpg"

                },
                new {
                    Email = "jane.doe@test.com",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "5555 Generic ave",
                    ProfileImage = "profile2.jpg"
                }
            };

            foreach (var user in testUsers)
            {
                CreateUser(user.Email, user.FirstName, user.LastName, user.Address, user.ProfileImage);
            }

        }

        private AppUser CreateUser(string email, string firstName, string lastName, string address, string profileImage)
        {
            if (_userManager.FindByNameAsync(email).Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    ProfileImage = profileImage
                };
                // add user
                var result = _userManager.CreateAsync(user, "password").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        public void AddTestRestaurant()
        {
            if (_restaurantRepo.GetAll().Count() > 0) return;
            var generic1 = CreateTestRestaurant("generic restaurant 1", 1, RestaurantType.FastFood, "Generic Food", 20.5, "9-5", "6666 generic ave", "picture1.jpg", false, "www.generic.com", "555-5555", true);
            var generic2 = CreateTestRestaurant("generic restaurant 2", 2, RestaurantType.Buffet, "Generic buffet Food", 15, "9-12", "7777 generic ave", "picture2.jpg", true, "www.generic2.com", "666-6666", false);
            _restaurantRepo.Add(generic1);
            _restaurantRepo.Add(generic2);
        }

        private Restaurant CreateTestRestaurant(string name, int id, RestaurantType type, string foodType, double averagePrices, string hours, string address, string pic, bool alcohol, string website, string phone, bool delivery)
        {
            var user1 = _userManager.FindByNameAsync("steven_schoor@yahoo.com").Result;
            var user2 = _userManager.FindByNameAsync("jane.doe@test.com").Result;

            return new Restaurant
            {
                RestaurantName = name,
                Id = id,
                RestaurantType = type,
                FoodType = foodType,
                PriceRange = averagePrices,
                HoursOfOperation = hours,
                Address = address,
                Image = pic,
                Alcohol = alcohol,
                RestaurantWebsite = website,
                PhoneNumber = phone,
                DeliveryService = delivery,
                UserReviews = new List<Review>
                {
                    new Review
                    {
                        UserId = user1.Id,
                        ReviewTitle = "Generic Review 1",
                        RestaurantId = id,
                        UserReview = "Blegh its to generic",
                        UserScore = 2,
                    },
                    new Review
                    {
                        UserId = user2.Id,
                        ReviewTitle = "Generic Review 2",
                        RestaurantId = id,
                        UserReview = "Blegh its super generic",
                        UserScore = 1,
                    },
                }
            };
        }

        private void AddAdminUser()
        {
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin", "admin", "1111 admin ave", "pic3");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }


        }
    }
}
