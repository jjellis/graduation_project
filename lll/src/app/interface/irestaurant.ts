export interface Restaurant {
    restaurantName: string;
    id: number;
    restaurantType: string;
    foodType: string;
    priceRange: number;
    hoursofOperation: string;
    address: string;
    image: string;
    alcohol: boolean;
    restaurantWebsite: string;
    phoneNumber: String;
    deliverService: string;
    averageUserScores: number;

        // public string RestaurantName { get; set; }
        // /*TODO public int Id { get; set; } int?
        // /*TODO public RestaurantType RestaurantType { get; set; } ????
        // public string FoodType { get; set; }
        // //Price range should be on a scale of 1-5
        // /*TODOpublic double PriceRange { get; set; } double??
        // public string HoursOfOperation { get; set; }
        // public string Address { get; set; }
        // /*TODO - Add a link to good api based off address*/
        // /*TODO - Add a picture*/
        // public string Image { get; set; }
        // public bool Alcohol { get; set; }
        // /*TODO - add link to yelp api*/
        // public string RestaurantWebsite { get; set; }
        // public string PhoneNumber { get; set; }
        // public bool DeliveryService { get; set; }
        // public double AverageUserScores 
}
