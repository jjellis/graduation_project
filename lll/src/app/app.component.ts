import { Component, OnInit } from '@angular/core';

import {RestaurantService} from './service/restaurant.service';
import{ReviewService} from './service/review.service';
import {Restaurant} from './interface/irestaurant';
import{Review} from './interface/ireview';
import { User } from "./interface/iuser";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthService } from './service/auth.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  Restaurants:Restaurant[];
  Reviews:[Review[]];
  
  currentUser:User;
  constructor(private authService:AuthService, private restaurantService:RestaurantService, private reviewService:ReviewService){}
  ngOnInit(){
    this.restaurantService.getAll().pipe(first())
    .subscribe(
        data => {
          
          this.Restaurants = data;
           
            console.log(Object.keys(data));
            data.forEach(restaurant=>{
              //comment
              console.log(restaurant.Id);
              debugger;
              this.reviewService.getAllReviewsForRestaurant(restaurant.Id).pipe(first())
              .subscribe(
                  data => {
                    this.Reviews[restaurant.Id] = data;
                    console.log(this.Reviews);
                      },
                  error => {
                      console.log(error);
                  });
            });
        },
        error => {
            console.log(error);
        });
        
        
      
      this.currentUser = this.authService.currentUserValue;
      console.log(this.currentUser);
      console.log(this.Reviews);
  }
}
