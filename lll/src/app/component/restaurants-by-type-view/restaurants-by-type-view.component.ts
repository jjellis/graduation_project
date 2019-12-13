import { Component, OnInit, OnDestroy} from '@angular/core';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {RestaurantService} from '../../service/restaurant.service';
import {Restaurant} from '../../interface/irestaurant';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-restaurants-by-type-view',
  template: '',
  templateUrl: './restaurants-by-type-view.component.html',
  styleUrls: ['./restaurants-by-type-view.component.css']
})
export class RestaurantsByTypeViewComponent implements OnInit{
  RestaurantTypeEnum = [
    
    {"id": 1, "name": "Family-Style"},
    {"id": 0, "name": "Fast-Food"},
    {"id": 2, "name": "Fine-Dining"},
    {"id": 3, "name": "Casual-Dining"},
    {"id": 4, "name": "Contemporary-Casual"},
    {"id": 5, "name": "Fast-Casual"},
    {"id": 6, "name": "Cafe"},
    {"id": 7, "name": "Buffet"},
    {"id": 8, "name": "Food-Truck"},
    {"id": 9, "name": "Concession-Stand"},
    {"id": 10, "name": "Popup-Restaurant"},
    {"id": 11, "name": "Ghost-Restaurant"},
];
restaurantTypeId:number;
public restaurantType;

Restaurants:Restaurant [];
  constructor(private route:ActivatedRoute, private restaurantService: RestaurantService, private router:Router) { }

  ngOnInit() {
   
    this.route.paramMap.subscribe((params:ParamMap) =>
    {
      let name = params.get('name');
      this.restaurantType = name;
      this.restaurantTypeId = this.RestaurantTypeEnum.find(type=>
        {
          console.log(this.restaurantType);
          let temp =  type.name.localeCompare(this.restaurantType);
         if(temp==0)
          return type
        }).id; 
        console.log(this.restaurantTypeId);
      this.restaurantService.getAll().pipe(first())
    .subscribe(
        data => {
          this.Restaurants = data;
          this.Restaurants = this.Restaurants.filter(restaurant=>{
            console.log(restaurant.restaurantType);
           if(restaurant.restaurantType == this.restaurantTypeId)
              return restaurant;
          });
        },

        error => {
            console.log(error);
        });
    })
 
  }
  onSelect(restaurant:Restaurant){
    this.router.navigate(["/restaurants", restaurant.id]);
  }


}
