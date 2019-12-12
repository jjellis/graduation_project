using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubbockLocalRestaurantAPI.APIModels
{
    public class ImageUploadModel
    {

        public IFormFile Image { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
