import { Component, OnInit, Input, OnChanges } from '@angular/core';
import {RestaurantService} from '../service/restaurant.service';
import {Restaurant} from '../interface/irestaurant';
import {ReviewService} from '../service/review.service';
import {Review} from '../interface/ireview';
import { first, timeout } from 'rxjs/operators';
import { async } from 'q';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';

@Component({
  selector: 'app-restaurantview',
  templateUrl: './restaurantView.component.html',
  styleUrls: ['./restaurantView.component.css']
})
export class RestaurantViewComponent implements OnInit {
  private restaurantId:number;
  private restaurant: Restaurant;
 Reviews: Review[];
 
  constructor( private restaurantService:RestaurantService, private reviewService:ReviewService, private router:Router, private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params:ParamMap) =>
    {
      let id = parseInt(params.get('id'));
      this.restaurantId = id;
    });
    this.restaurantService.get(this.restaurantId).subscribe(
      data => {
        this.restaurant = data;
      },
      error =>{
        console.log(error);
      });
    this.reviewService.getAllReviewsForRestaurant(this.restaurantId).pipe(first())
              .subscribe(
                  data => {
                    this.Reviews = data;
                      },
                  error => {
                      console.log(error);
                  });
  }
  



 
}
