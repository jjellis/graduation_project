import { Component, OnInit } from '@angular/core';
import {RestaurantService} from '../service/restaurant.service';
import {Restaurant} from '../interface/irestaurant';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-restaurantview',
  templateUrl: './restaurantView.component.html',
  styleUrls: ['./restaurantView.component.css']
})
export class RestaurantViewComponent implements OnInit {
 restaurants:Restaurant [];
  constructor(private restaurantService:RestaurantService) { }

  ngOnInit() {
    this.restaurantService.getAll().pipe(first())
    .subscribe(
        data => {
          this.restaurants = data;
            console.log(data);
        },
        error => {
            console.log(error);
        });
  }

}
