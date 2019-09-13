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
                var result = _userManager.CreateAsync(user, "Password12#").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        public void AddTestRestaurant()
        {
            if (_restaurantRepo.GetAll().Count() > 0) return;
            var generic1 = CreateTestRestaurant("generic restaurant 1", 1, RestaurantType.FastFood, "Generic Food", 20.5, "9-5", "6666 generic ave", "picture1.jpg", false, "www.generic.com", "555-5555", true, " ");
            var generic2 = CreateTestRestaurant("generic restaurant 2", 2, RestaurantType.Buffet, "Generic buffet Food", 15, "9-12", "7777 generic ave", "picture2.jpg", true, "www.generic2.com", "666-6666", false, " ");
            var real = CreateTestRestaurant("applebees grill bar lubbock", 3, RestaurantType.FamilyStyle, "American Bar and grill", 11, "11-12", "025 S Loop 289, Lubbock, TX 79423", @"https://s3-media2.fl.yelpcdn.com/bphoto/MMidaq5xH86SPi-dJWhWfw/o.jpg\", true, @"https://www.applebees.com/en", "+18067854025", false, "{\"businesses\": [{\"id\": \"4w0gvAjfFJbjP1_GX7jWxA\", \"alias\": \"applebees-grill-bar-lubbock\", \"name\": \"Applebee's Grill + Bar\", \"image_url\": \"https://s3-media2.fl.yelpcdn.com/bphoto/MMidaq5xH86SPi-dJWhWfw/o.jpg\", \"is_closed\": false, \"url\": \"https://www.yelp.com/biz/applebees-grill-bar-lubbock?adjust_creative=dkkmRxsUIEmWGpLseCr51g&utm_campaign=yelp_api_v3&utm_medium=api_v3_phone_search&utm_source=dkkmRxsUIEmWGpLseCr51g\", \"review_count\": 55, \"categories\": [{\"alias\": \"tradamerican\", \"title\": \"American (Traditional)\"}, {\"alias\": \"sportsbars\", \"title\": \"Sports Bars\"}, {\"alias\": \"burgers\", \"title\": \"Burgers\"}], \"rating\": 2.0, \"coordinates\": {\"latitude\": 33.528844, \"longitude\": -101.901284}, \"transactions\": [\"delivery\"], \"price\": \"$$\", \"location\": {\"address1\": \"4025 South Loop 289\", \"address2\": \"\", \"address3\": \"\", \"city\": \"Lubbock\", \"zip_code\": \"79423\", \"country\": \"US\", \"state\": \"TX\", \"display_address\": [\"4025 South Loop 289\", \"Lubbock, TX 79423\"]}, \"phone\": \"+18067854025\", \"display_phone\": \"(806) 785-4025\"}], \"total\": 1}");
            _restaurantRepo.Add(generic1);
            _restaurantRepo.Add(generic2);
            _restaurantRepo.Add(real);
        }

        private Restaurant CreateTestRestaurant(string name, int id, RestaurantType type, string foodType, double averagePrices, string hours, string address, string pic, bool alcohol, string website, string phone, bool delivery, string yelp)
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
                YelpJSON = yelp,
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
