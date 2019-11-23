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
 currentUser:User;
  constructor(private authService:AuthService, private restaurantService:RestaurantService){}
  ngOnInit(){
    
      this.currentUser = this.authService.currentUserValue;
  }
  
}
