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
  private restaurantId:number;
 @Input() childRestaurant:Restaurant;   
 Reviews: Review[];
 
  constructor( private reviewService:ReviewService) { }

  ngOnInit() {
    this.reviewService.getAllReviewsForRestaurant(this.childRestaurant.id).pipe(first())
              .subscribe(
                  data => {
                    this.Reviews = data;
                      },
                  error => {
                      console.log(error);
                  });
  }
  



 
}
