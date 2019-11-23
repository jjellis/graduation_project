import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../service/auth.service';
import {RestaurantService} from '../../service/restaurant.service';
import {Restaurant} from '../../interface/irestaurant';
import {NgbModule, NgbButtonsModule} from '@ng-bootstrap/ng-bootstrap'
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  Restaurants:Restaurant [];
  constructor(private authService:AuthService, private restaurantService: RestaurantService) { }

  ngOnInit() {
    this.restaurantService.getAll().pipe(first())
    .subscribe(
        data => {
          this.Restaurants = data;
        },
        error => {
            console.log(error);
        });
      
  }
  logout(){
    this.authService.logout();
    
  }

  
}
