import { Component, OnInit, OnDestroy, PipeTransform} from '@angular/core';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {RestaurantService} from '../../service/restaurant.service';
import {Restaurant} from '../../interface/irestaurant';
import { first, startWith, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { DecimalPipe } from '@angular/common';
import { async } from '@angular/core/testing';





@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [DecimalPipe]
})
export class SearchComponent implements OnInit {
  Restaurants:Restaurant [];
  restaurants$: Observable<Restaurant[]>;
  filter = new FormControl('');
  public restaurantType;
  restaurantTypeId:number;
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
  constructor(pipe: DecimalPipe, private route:ActivatedRoute, private restaurantService: RestaurantService, private router:Router) {
    

    this.restaurants$ = this.filter.valueChanges.pipe(
      startWith(''),
      map(text => this.search(text, pipe))
    );
   }

  ngOnInit() {
    async (()=> {
      this.restaurantService.getAll().pipe(first())
      .subscribe(
          data => {
            this.Restaurants = data;
            
           console.log(this.Restaurants);
          },
  
          error => {
              console.log(error);
          });
    }); 

        
}

  onSelect(restaurant:Restaurant){
    this.router.navigate(["/restaurants", restaurant.id]);
  }

  search(text: string, pipe: PipeTransform): Restaurant[] {
    console.log(this.Restaurants);
    return this.Restaurants.filter(filt => {
      const term = text.toLowerCase();
      return filt.restaurantName.toLowerCase().includes(term)
          || pipe.transform(filt.address).includes(term)
          || pipe.transform(filt.foodType).includes(term);
    });
  }
  

}

