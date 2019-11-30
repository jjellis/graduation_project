import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../service/auth.service';
import {Restaurant} from '../../interface/irestaurant';
import {NgbModule, NgbButtonsModule} from '@ng-bootstrap/ng-bootstrap'

import {Router, ParamMap} from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  collapsed = true;
  
  RestaurantType = [
    
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

  constructor(private authService:AuthService, private router:Router) { }

  ngOnInit() {
    
  }
  logout(){
    this.authService.logout();
    
  }
  onSelect(type){
    this.router.navigate(["/restaurantsByType", type.name]);
  
      
  }

  
}
