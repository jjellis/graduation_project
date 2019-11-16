import { Component, OnInit, Input, OnChanges } from '@angular/core';
import {RestaurantService} from '../service/restaurant.service';
import {Restaurant} from '../interface/irestaurant';
import {ReviewService} from '../service/review.service';
import {Review} from '../interface/ireview';
import { first, timeout } from 'rxjs/operators';
import { async } from 'q';

@Component({
  selector: 'app-restaurantview',
  templateUrl: './restaurantView.component.html',
  styleUrls: ['./restaurantView.component.css']
})
export class RestaurantViewComponent implements OnInit {
 @Input() childRestaurant:Restaurant;
 Reviews: Review[];
 
  constructor(private restaurantService:RestaurantService, private reviewService:ReviewService) { }

  ngOnInit() {
    
  }
  



 
}
